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
    [RoutePrefix("AppicoContact")]
    public class ContactController : ApiController
    {

        private AppicoExecutor appicoExecutor;

        public ContactController(){
            appicoExecutor = new AppicoExecutor();
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult ContactInfo(ContactInputDto contactData) {
            appicoExecutor.InitExecutor()
                          .CommandHandler(CommandTypes.CreateContact)
                          .CommandParameterAdd(contactData)
                          .ExecuteCommand();
            return Ok();
        }

        [Route("list")]
        [HttpGet]
        public IHttpActionResult ContactInfo() { 
            var listOfContact = appicoExecutor.InitExecutor()
                                              .CommandHandler(CommandTypes.ContactList)
                                              .ExecuteCommand();
            return Ok(JsonConvert.SerializeObject(listOfContact));
        }

    }
}
