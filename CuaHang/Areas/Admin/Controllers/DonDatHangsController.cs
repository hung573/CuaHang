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
    public class DonDatHangsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/DonDatHangs
        public ActionResult Index()
        {
            var donDatHang = db.DonDatHang.Include(d => d.KhanhHang);
            return View(donDatHang.ToList());
        }

        // GET: Admin/DonDatHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // GET: Admin/DonDatHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhanhHang, "MaKH", "HoTen");
            return View();
        }

        // POST: Admin/DonDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,DaThanhToan,Tinhtranggiaohang,Ngaydat,Ngaygiao,MaKhachHang")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHang.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhanhHang, "MaKH", "HoTen", donDatHang.MaKhachHang);
            return View(donDatHang);
        }

        // GET: Admin/DonDatHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhanhHang, "MaKH", "HoTen", donDatHang.MaKhachHang);
            return View(donDatHang);
        }

        // POST: Admin/DonDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,DaThanhToan,Tinhtranggiaohang,Ngaydat,Ngaygiao,MaKhachHang")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhanhHang, "MaKH", "HoTen", donDatHang.MaKhachHang);
            return View(donDatHang);
        }

        // GET: Admin/DonDatHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // POST: Admin/DonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            db.DonDatHang.Remove(donDatHang);
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
