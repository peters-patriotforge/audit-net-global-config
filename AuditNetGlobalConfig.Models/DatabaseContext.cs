using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Audit.EntityFramework;

namespace AuditNetGlobalConfig.Models
{
    public class DatabaseContext : AuditDbContext
    {
        public DatabaseContext(string contextName) : base(contextName)
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

        public DatabaseContext() : base("name=AuditNetTestDb") { }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<ShopOrderNote> ShopOrderNotes { get; set; }
    }
}
