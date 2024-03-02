namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class AccountModel
    {
        [Key]
        [StringLength(50)]
        [DisplayName("Tai Khoan:")]
        public string Username { get; set; }

        [StringLength(20)]
        [DisplayName("Mat Khau:")]
        public string Password { get; set; }
    }
}
