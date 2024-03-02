namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhanhHang")]
    public partial class KhanhHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhanhHang()
        {
            DonDatHang = new HashSet<DonDatHang>();
        }

        [Key]
        public int MaKH { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string DiaChiKH { get; set; }

        [StringLength(20)]
        public string DienthoaiKH { get; set; }

        public DateTime? NgaySinh { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHang { get; set; }
    }
}
