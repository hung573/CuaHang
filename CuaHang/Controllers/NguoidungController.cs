using CuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHang.Controllers
{

    public class NguoidungController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangKy(FormCollection collection, KhanhHang kh)
        {
            DBContext db = new DBContext();
            var hoten = collection["HoTenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var nhaplaimatkhau = collection["Matkhaunhaplai"];
            var diachi = collection["DiaChi"];
            var email = collection["email"];
            var dienthoai = collection["DienThoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được để tróng";
            }
            else if (String.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewData["Loi4"] = "Nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi5"] = "Địa chỉ không được bỏ trống";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi6"] = "Email không được bỏ trống";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "Phải nhập số điện thoại";
            }
            else if (String.IsNullOrEmpty(ngaysinh))
            {
                ViewData["Loi7"] = "Phải điền ngày sinh của bạn";
            }
            else
            {
                kh.HoTen = hoten;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DiaChiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                db.KhanhHang.Add(kh);
                db.SaveChangesAsync();
                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangNhap(FormCollection collection)
        {
            DBContext db = new DBContext();
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "phai nhap tai khoan";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Ban chua nhap Mat Khau";
            }
            else
            {
                KhanhHang kh = db.KhanhHang.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
                if(kh == null)
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                /*else if (kh.MatKhau == matkhau)
                {

                    return Redirect("/Home/Index");
                }*/
                else
                {
                    Session["TaiKhoan"] = kh; 
                    return Redirect("/Home/Index");
                }
            }
            return View();

        }
    }
}