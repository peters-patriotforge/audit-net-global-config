using System.Collections.Generic;
using Audit.Core;
using AuditNetGlobalConfig.Security.Models;

namespace AuditNetGlobalConfig.DataAccess
{
    public class AccessEngine
    {
        private readonly string _connectionName;

        public AccessEngine(string connectionName)
        {
            _connectionName = connectionName;
        }

        public void AddAccesses(List<Access> accesses)
        {
            using (var context = new SecurityDatabaseContext(_connectionName))
            {
                context.Accesses.AddRange(accesses);

                context.SaveChanges();
            }
        }
    }
}
