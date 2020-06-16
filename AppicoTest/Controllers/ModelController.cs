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
    [RoutePrefix("AppicoModel")]
    public class ModelController : ApiController
    {
        private AppicoExecutor appicoExecutor;

        public ModelController()
        {
            appicoExecutor = new AppicoExecutor();
        }

        [Route("List")]
        [HttpGet]
        public IHttpActionResult ModelInfo()
        {
            var listOfModels = appicoExecutor.InitExecutor()
                                             .CommandHandler(CommandTypes.ModelList)
                                             .ExecuteCommand();
            return Ok(JsonConvert.SerializeObject(listOfModels));
        }
    }
}
