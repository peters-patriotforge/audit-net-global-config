using System.Collections.Generic;
using System.Web.Http;
using AuditNetGlobalConfig.Logic;

namespace AuditNetGlobalConfig.WebApi.Controllers
{
    public class AccessController : ApiController
    {
        [HttpPost]
        [Route("api/accesses")]
        public void AddAccesses(List<AccessAddDto> accessAddDtos)
        {
            var accessLogic = new AccessLogic("AuditNetTestSecurityDb");

            accessLogic.AddAccesses(accessAddDtos);
        }
    }
}
