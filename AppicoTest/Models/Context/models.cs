namespace AppicoTest.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class models
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public models()
        {
            inventory = new HashSet<inventory>();
        }

        [Key]
        public int guid { get; set; }

        [Required]
        public string make { get; set; }

        [Required]
        public string model { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public string year { get; set; }
        public virtual ICollection<inventory> inventory { get; set; }
    }
}
