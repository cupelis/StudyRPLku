namespace StudyRPLku.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Reviews = new HashSet<Reviews>();
            ShoppingCarts = new HashSet<ShoppingCarts>();
        }

        [Key]
        public int BookID { get; set; }

        public int AuthorID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublicationDate { get; set; }

        [StringLength(50)]
        public string ISBN { get; set; }

        [StringLength(50)]
        public string CoverImage { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Publisher { get; set; }

        public virtual Authors Authors { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reviews> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCarts> ShoppingCarts { get; set; }
    }
}
