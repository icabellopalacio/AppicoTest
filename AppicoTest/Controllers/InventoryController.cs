using AppicoTest.Models.Dtos;
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
    [RoutePrefix("AppicoInventory")]
    public class InventoryController : ApiController
    {
        private AppicoExecutor appicoExecutor;

        public InventoryController()
        {
            appicoExecutor = new AppicoExecutor();
        }

        [Route("List")]
        [HttpGet]
        public IHttpActionResult InventoryInfo()
        {
            var listOfInventory = appicoExecutor.InitExecutor()
                                                .CommandHandler(CommandTypes.InventoryList)
                                                .ExecuteCommand();
            return Ok(JsonConvert.SerializeObject(listOfInventory));
        }
    }
}
