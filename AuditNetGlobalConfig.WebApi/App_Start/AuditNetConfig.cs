using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Audit.Core;
using Audit.EntityFramework.Providers;
using AuditNetGlobalConfig.Models;
using AuditNetGlobalConfig.Security.Models;

namespace AuditNetGlobalConfig.WebApi.App_Start
{
    public class AuditNetConfig
    {
        public static void Configure()
        {
            Audit.Core.Configuration.Setup()
                .UseCustomProvider(new MultiEntityFrameworkDataProvider());

            var dp = Audit.Core.Configuration.DataProvider as MultiEntityFrameworkDataProvider;

            dp.AttachDataProvider<DatabaseContext>(new EntityFrameworkDataProvider(ef => ef
                .UseDbContext<DatabaseContext>()
                    .AuditTypeMapper(t => typeof(Models.AuditLog))
                    .AuditEntityAction<Models.AuditLog>((ev, entry, entity) =>
                    {
                        entity.AuditData = entry.ToJson();
                        entity.EntityType = entry.EntityType.Name;
                        entity.AuditDate = DateTime.Now;
                        entity.TablePk = entry.PrimaryKey.First().Value.ToString();
                    })
                    .IgnoreMatchedProperties(true)));
            
            dp.AttachDataProvider<SecurityDatabaseContext>(new EntityFrameworkDataProvider(ef => ef
                .UseDbContext<SecurityDatabaseContext>()
                    .AuditTypeMapper(t => typeof(Security.Models.AuditLog))
                    .AuditEntityAction<Security.Models.AuditLog>((ev, entry, entity) =>
                    {
                        entity.AuditData = entry.ToJson();
                        entity.EntityType = entry.EntityType.Name;
                        entity.AuditDate = DateTime.Now;
                        entity.TablePk = entry.PrimaryKey.First().Value.ToString();
                    })
                    .IgnoreMatchedProperties(true)));
        }
    }
}