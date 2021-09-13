using System.Data.Entity.Migrations;

namespace AuditNetGlobalConfig.Security.Models.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SecurityDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AuditNetGlobalConfig.Models.SecurityDatabaseContext";
        }
    }
}
