using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHang.Models;

namespace CuaHang.Areas.Admin.Controllers
{
    public class KhanhHangsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/KhanhHangs
        public ActionResult Index()
        {
            return View(db.KhanhHang.ToList());
        }

        // GET: Admin/KhanhHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhanhHang khanhHang = db.KhanhHang.Find(id);
            if (khanhHang == null)
            {
                return HttpNotFound();
            }
            return View(khanhHang);
        }

        // GET: Admin/KhanhHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhanhHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTen,TaiKhoan,MatKhau,Email,DiaChiKH,DienthoaiKH,NgaySinh,IsDeleted")] KhanhHang khanhHang)
        {
            if (ModelState.IsValid)
            {
                db.KhanhHang.Add(khanhHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khanhHang);
        }

        // GET: Admin/KhanhHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhanhHang khanhHang = db.KhanhHang.Find(id);
            if (khanhHang == null)
            {
                return HttpNotFound();
            }
            return View(khanhHang);
        }

        // POST: Admin/KhanhHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTen,TaiKhoan,MatKhau,Email,DiaChiKH,DienthoaiKH,NgaySinh,IsDeleted")] KhanhHang khanhHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khanhHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khanhHang);
        }

        // GET: Admin/KhanhHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhanhHang khanhHang = db.KhanhHang.Find(id);
            if (khanhHang == null)
            {
                return HttpNotFound();
            }
            return View(khanhHang);
        }

        // POST: Admin/KhanhHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhanhHang khanhHang = db.KhanhHang.Find(id);
            db.KhanhHang.Remove(khanhHang);
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
    }
}
