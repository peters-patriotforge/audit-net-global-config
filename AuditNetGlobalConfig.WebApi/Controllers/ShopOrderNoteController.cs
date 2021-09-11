using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuditNetGlobalConfig.Logic;

namespace AuditNetGlobalConfig.WebApi.Controllers
{
    public class ShopOrderNoteController : ApiController
    {
        [HttpPost]
        [Route("api/shop-order-notes")]
        public void AddShopOrderNotes(List<ShopOrderNoteAddDto> shopOrderNoteAddDtos)
        {
            var shopOrderNoteLogic = new ShopOrderNoteLogic("AuditNetTestDb");

            shopOrderNoteLogic.AddShopOrderNotes(shopOrderNoteAddDtos);
        }
    }
}
