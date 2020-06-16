using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Dtos
{
    public class ContactOutputDto
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string DealerName { get; set; }
        public string ModelMake { get; set; }
        public string ModelName { get; set; }
        public string ModelType { get; set; }
        public string Message { get; set; }
        public string CreatedDate { get; set; }
    }
}