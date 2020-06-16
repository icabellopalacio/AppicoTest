using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Dtos
{
    public class ContactInputDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int DealerId { get; set; }
        public int ModelId { get; set; }
        public string Message { get; set; }
    }
}