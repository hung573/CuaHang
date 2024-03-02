namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageProduct")]
    public partial class ImageProduct
    {
        [DisplayName("Ma")]
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Hinh anh")]
        public string Image { get; set; }

        [DisplayName("San Pham")]
        public int IDProduct { get; set; }

        public virtual Product Product { get; set; }
    }
}
