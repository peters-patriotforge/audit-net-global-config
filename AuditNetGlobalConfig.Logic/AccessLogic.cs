using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditNetGlobalConfig.DataAccess;
using AuditNetGlobalConfig.Security.Models;

namespace AuditNetGlobalConfig.Logic
{
    public class AccessLogic
    {
        private readonly string _connectionName;
        private readonly AccessEngine _accessEngine;

        public AccessLogic(string connectionName)
        {
            _connectionName = connectionName;
            _accessEngine = new AccessEngine(_connectionName);
        }

        public void AddAccesses(List<AccessAddDto> accessAddDtos)
        {
            var currentDateTime = DateTime.Now;

            var accesses = accessAddDtos.Select(x => new Access()
            {
                CreatedDateTime = currentDateTime,
                DataValue = x.DataValue
            }).ToList();

            _accessEngine.AddAccesses(accesses);
        }
    }
}
