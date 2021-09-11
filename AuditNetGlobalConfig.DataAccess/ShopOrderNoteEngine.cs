using System.Collections.Generic;
using AuditNetGlobalConfig.Models;

namespace AuditNetGlobalConfig.DataAccess
{
    public class ShopOrderNoteEngine
    {
        private readonly string _connectionName;

        public ShopOrderNoteEngine(string connectionName)
        {
            _connectionName = connectionName;
        }

        public void AddShopOrderNotes(List<ShopOrderNote> shopOrderNotes)
        {
            using (var context = new DatabaseContext(_connectionName))
            {
                context.ShopOrderNotes.AddRange(shopOrderNotes);

                context.SaveChanges();
            }
        }
    }
}
