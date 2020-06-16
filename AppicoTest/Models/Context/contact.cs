namespace AppicoTest.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contact")]
    public partial class contact
    {
        [Key]
        public int guid { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        public string message { get; set; }

        public DateTime created { get; set; }

        public int dealer { get; set; }

        public int model { get; set; }
    }
}
