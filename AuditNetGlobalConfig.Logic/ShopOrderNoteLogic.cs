using System;
using System.Collections.Generic;
using System.Linq;
using AuditNetGlobalConfig.DataAccess;
using AuditNetGlobalConfig.Models;

namespace AuditNetGlobalConfig.Logic
{
    public class ShopOrderNoteLogic
    {
        private readonly string _connectionName;
        private readonly ShopOrderNoteEngine _shopOrderNoteEngine;

        public ShopOrderNoteLogic(string connectionName)
        {
            _connectionName = connectionName;
            _shopOrderNoteEngine = new ShopOrderNoteEngine(_connectionName);
        }

        public void AddShopOrderNotes(List<ShopOrderNoteAddDto> shopOrderNoteAddDtos)
        {
            var currentDateTime = DateTime.Now;

            var shopOrderNotes = shopOrderNoteAddDtos.Select(x => new ShopOrderNote()
            {
                CreatedDateTime = currentDateTime,
                DataValue = x.DataValue
            }).ToList();

            _shopOrderNoteEngine.AddShopOrderNotes(shopOrderNotes);
        }
    }
}
