namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDonHang { get; set; }
        
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSP { get; set; }

        public int? Soluong { get; set; }

        public decimal? Dongia { get; set; }
        public bool? IsDelet { get; set; }


        public virtual DonDatHang DonDatHang { get; set; }

        public virtual Product Product { get; set; }
    }
}
