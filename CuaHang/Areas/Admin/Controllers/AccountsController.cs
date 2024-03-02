using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using CuaHang.Models;

namespace CuaHang.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/Accounts
        public ActionResult Index()
        {
            return View(db.Account.ToList());
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();  
            }
            return View(account);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password")] AccountModel account)
        {
            if (ModelState.IsValid)
            {
                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password")] AccountModel account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]      
        public ActionResult DeleteConfirmed(string id)
        {
            AccountModel account = db.Account.Find(id);
            db.Account.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Admin/Account
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string tenDangNhap, string matKhau)
        {

            //1.Kiểm tra tên đăng nhập  hoặc mật khẩu có trống => Trở về trang đăng nhập: Thông báo thiếu thông tin
            if (string.IsNullOrEmpty(tenDangNhap) == true || string.IsNullOrEmpty(matKhau) == true)
            {
                ViewBag.error = "Thông báo thiếu thông tin (1)";
                return View();
            }

            //2.Tìm tài khoản theo tên đăng nhập trong database
            AccountModel taiKhoan = db.Account.SingleOrDefault(n => n.Username == tenDangNhap && n.Password == matKhau);
            //3.Kiểm tra tồn tại tài khoản => nếu ko tồn tại => Trở về trang đăng nhập: Tài khoản hoặc mật khẩu không đúng
            if (taiKhoan == null)
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu không đúng (3)";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }

            //4.Kiểm tra mật khẩu => nếu sai => trở về trang đăng nhập: Tài khoản hoặc mật khẩu không đúng
            if (taiKhoan.Password != matKhau)
            {

                return Redirect("/Admin/Accounts/Index");
            }
            //7.Chuyển hướng sang trang chủ Admin
            return Redirect("/Admin/Accounts/Index");
        }
    }
}
