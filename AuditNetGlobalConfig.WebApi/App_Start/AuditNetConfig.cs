using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Audit.Core;
using AuditNetGlobalConfig.Models;

namespace AuditNetGlobalConfig.WebApi.App_Start
{
    public class AuditNetConfig
    {
        public static void Configure()
        {
            Audit.Core.Configuration.Setup()
                .UseEntityFramework(_ => _
                    .AuditTypeMapper(t => typeof(AuditLog))
                    .AuditEntityAction<AuditLog>((ev, entry, entity) =>
                    {
                        entity.AuditData = entry.ToJson();
                        entity.EntityType = entry.EntityType.Name;
                        entity.AuditDate = DateTime.Now;
                        entity.TablePk = entry.PrimaryKey.First().Value.ToString();
                    })
                    .IgnoreMatchedProperties(true));

            Audit.EntityFramework.Configuration.Setup()
                .ForContext<DatabaseContext>()
                .UseOptOut();
        }
    }
}