namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        DBContext db = new DBContext();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ImageProduct = new HashSet<ImageProduct>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }
        
        [DisplayName("Ma San Pham")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ten San Pham")]
        public string Name { get; set; }

        [DisplayName("Gia San Pham")]
        public int Cost { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Thong Tin San Pham")]
        public string Desceiption { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi Tiet San Pham")]
        public string Details { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Hinh San Pham")]
        public string Image { get; set; }

        [DisplayName("San Pham Giam Gia")]
        public bool? IsSeller { get; set; }

        [DisplayName("San Pham Ban Chay")]
        public bool? OnTop { get; set; }

        [DisplayName("Loai San Pham")]
        public int IDCategory { get; set; }

        [DisplayName("Hang San Pham")]
        public int IDBrand { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }


        public Product ChiTiet(int id)
        {
            try
            {
                return db.Product.Find(id);
            }
            catch
            {
                return new Product();
            }
        }
    }
}
