using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.EntityFramework;

namespace AuditNetGlobalConfig.Security.Models
{
    public class SecurityDatabaseContext : AuditDbContext
    {
        public SecurityDatabaseContext(string contextName) : base(contextName)
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public SecurityDatabaseContext() : base("name=AuditNetTestSecurityDb") { }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Access> Accesses { get; set; }
    }
}
