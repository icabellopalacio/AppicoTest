namespace AppicoTest.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inventory")]
    public partial class inventory
    {
        [Key]
        public int guid { get; set; }

        public int dealer { get; set; }

        public int model { get; set; }

        [Required]
        public string vin { get; set; }

        public virtual dealer dealer1 { get; set; }

        public virtual models models { get; set; }
    }
}
