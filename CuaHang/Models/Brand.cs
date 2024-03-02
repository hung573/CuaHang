namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            Product = new HashSet<Product>();
        }
        [DisplayName("Ma brand")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ten brand")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Hinh brand")]
        public string Image { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [DisplayName("San Pham")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
