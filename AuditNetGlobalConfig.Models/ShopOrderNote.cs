using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditNetGlobalConfig.Models
{
    public class ShopOrderNote
    {
        public int ShopOrderNoteId {get;set;}

        public string DataValue { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
