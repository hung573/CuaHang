using CuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHang.Controllers
{
    public class GioHangController : Controller
    {
        DBContext db = new DBContext();
        // GET: GioHang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult Themgiohang(int iMaSP, string strURL)
        {
            List<GioHang> lstGioHang = Laygiohang();
            GioHang giohang = lstGioHang.Find(n => n.iMaSP == iMaSP);
            if(giohang == null)
            {
                giohang = new GioHang(iMaSP);
                lstGioHang.Add(giohang);
                return Redirect(strURL);
            }
            else
            {
                giohang.iSoluong++;
                return Redirect(strURL);
            }
            
        }
        public int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        public double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                iTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return iTongTien;
        }
        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = Laygiohang();
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGioHang);
        }
        public ActionResult Giohangpartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult xoaGioHang(int iMaSp)
        {
            List<GioHang> lstGioHang = Laygiohang();
            GioHang giohang = lstGioHang.SingleOrDefault(n=>n.iMaSP ==iMaSp);
            if(giohang != null)
            {
                lstGioHang.RemoveAll(n=>n.iMaSP == iMaSp);
                return RedirectToAction("GioHang");
            }
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGioHang(int iMaSp, FormCollection f)
        {
            List<GioHang> lstGioHang = Laygiohang();
            GioHang giohang = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSp);
            if(giohang != null)
            {
                giohang.iSoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoatatcaGioHang()
        {
            List<GioHang> lstGioHang = Laygiohang();
            lstGioHang.Clear();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Nguoidung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGioHang);
        }
        public  ActionResult DatHang(FormCollection collection)
        {
            DBContext db = new DBContext();
            DonDatHang ddh = new DonDatHang();
            KhanhHang kh = (KhanhHang)Session["TaiKhoan"];
            List<GioHang> gh = Laygiohang();
            ddh.MaKhachHang = kh.MaKH;
            ddh.Ngaydat = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            ddh.Ngaygiao = DateTime.Parse(ngaygiao);
            ddh.Tinhtranggiaohang = false;
            ddh.DaThanhToan = false;
            db.DonDatHang.Add(ddh);
            db.SaveChangesAsync();
            foreach (var item in gh)                         
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaSP = item.iMaSP;
                ctdh.Soluong = item.iSoluong;
                ctdh.Dongia = (decimal)item.dDongia;
                db.ChiTietDonHang.Add(ctdh);

            }
            
            Session["GioHang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }

}