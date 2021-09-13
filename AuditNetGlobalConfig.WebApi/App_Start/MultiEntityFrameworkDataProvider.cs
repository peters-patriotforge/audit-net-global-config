using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Audit.Core;
using Audit.EntityFramework;
using Audit.EntityFramework.Providers;

namespace AuditNetGlobalConfig.WebApi.App_Start
{
    public class MultiEntityFrameworkDataProvider : AuditDataProvider
    {
        // Store a list of Condition->DataProvider
        private List<ValueTuple<Func<AuditEvent, bool>, EntityFrameworkDataProvider>> _providers = 
            new List<ValueTuple<Func<AuditEvent, bool>, EntityFrameworkDataProvider>>();
        // Adds a new data provider to the list, depending on the DbContext type T
        public void AttachDataProvider<T>(EntityFrameworkDataProvider dataProvider)
            where T : DbContext
        {
            Func<AuditEvent, bool> condition = ev => ev.GetEntityFrameworkEvent()?.GetDbContext() is T;
            AttachDataProvider(condition, dataProvider);
        }

        public void AttachDataProvider(Func<AuditEvent, bool> condition, EntityFrameworkDataProvider dataProvider)
        {
            _providers.Add((condition, dataProvider));
        }

        public override object InsertEvent(AuditEvent auditEvent)
        {
            foreach ((Func<AuditEvent, bool> condition, EntityFrameworkDataProvider dataProvider) in _providers)
            {
                if (condition.Invoke(auditEvent))
                {
                    dataProvider.InsertEvent(auditEvent);
                    break;
                }
            }
            return null;
        }

        public async override Task<object> InsertEventAsync(AuditEvent auditEvent)
        {
            foreach ((Func<AuditEvent, bool> condition, EntityFrameworkDataProvider dataProvider) in _providers)
            {
                if (condition.Invoke(auditEvent))
                {
                    await dataProvider.InsertEventAsync(auditEvent);
                    break;
                }
            }
            return null;
        }
    }
}