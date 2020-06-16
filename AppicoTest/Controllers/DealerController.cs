using AppicoTest.Models.Executors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppicoTest.Controllers
{
    [RoutePrefix("AppicoDealer")]
    public class DealerController : ApiController
    {
        private AppicoExecutor appicoExecutor;

        public DealerController()
        {
            appicoExecutor = new AppicoExecutor();
        }

        [Route("List")]
        [HttpGet]
        public IHttpActionResult DealerInfo()
        {
            var listOfDealer = appicoExecutor.InitExecutor()
                                             .CommandHandler(CommandTypes.DealerList)
                                             .ExecuteCommand();
            return Ok(JsonConvert.SerializeObject(listOfDealer));
        }
    }
}
