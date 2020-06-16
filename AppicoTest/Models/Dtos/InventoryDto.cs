using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Dtos
{
    public class InventoryDto
    {
        public string VIN { get; set; }
        public string DealerName{ get; set; }
        public string ModelMake{ get; set; }
        public string ModelName{ get; set; }
        public string ModelType{ get; set; }
    }
}