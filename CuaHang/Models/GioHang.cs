using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHang.Models
{

    public class GioHang
    {
        DBContext db = new DBContext();
        public int iMaSP { set; get; }
        public string sTenSP { set; get; }
        public string dAnh { get; set; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhTien
        {
            get { return iSoluong * dDongia; }
        }
        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            Product product = db.Product.Single(n=>n.ID==iMaSP);
            sTenSP = product.Name;
            dAnh = product.Image;
            dDongia = double.Parse(product.Cost.ToString());
            iSoluong = 1;
        }
    }
}