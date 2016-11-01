namespace StudyRPLku.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCarts
    {
        [Key]
        public int RecordID { get; set; }

        [Required]
        [StringLength(50)]
        public string CardID { get; set; }

        public int Quantity { get; set; }

        public int BookID { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Books Books { get; set; }
    }
}
