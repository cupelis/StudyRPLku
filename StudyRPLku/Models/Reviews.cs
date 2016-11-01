namespace StudyRPLku.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviews
    {
        [Key]
        public int ReviewID { get; set; }

        public int BookID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public int? Rating { get; set; }

        public string Comments { get; set; }

        public virtual Books Books { get; set; }
    }
}
