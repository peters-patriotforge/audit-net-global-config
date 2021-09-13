using System;

namespace AuditNetGlobalConfig.Security.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public string AuditData { get; set; }
        public string EntityType { get; set; }
        public DateTime AuditDate { get; set; }
        public int? AuditUserId { get; set; }
        public string TablePk { get; set; }
        public string Comment { get; set; }
    }
}
