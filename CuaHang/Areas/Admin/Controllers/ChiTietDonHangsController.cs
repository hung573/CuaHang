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
    public class ChiTietDonHangsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/ChiTietDonHangs
        public ActionResult Index()
        {

            var chiTietDonHang = db.ChiTietDonHang.Include(i => i.Product).Include(i => i.DonDatHang);
            return View(chiTietDonHang.ToList());
        }

        // GET: Admin/ChiTietDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.Product, "ID", "Name");
            ViewBag.MaDonHang = new SelectList(db.DonDatHang, "MaDonHang", "MaKH");
            return View();
        }

        // POST: Admin/ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,MaSP,Soluong,Dongia,IsDelet")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                chiTietDonHang.IsDelet = false;
                db.ChiTietDonHang.Add(chiTietDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.Product, "ID", "Name", chiTietDonHang.MaSP);
            ViewBag.MaDonHang = new SelectList(db.DonDatHang, "MaDonHang", "MaKH", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.Product, "ID", "Name", chiTietDonHang.MaSP);
            ViewBag.MaDonHang = new SelectList(db.DonDatHang, "MaDonHang", "MaKH", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }

        // POST: Admin/ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,MaSP,Soluong,Dongia,IsDelet")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                chiTietDonHang.IsDelet = false;
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.Product, "ID", "Name", chiTietDonHang.MaSP);
            ViewBag.MaDonHang = new SelectList(db.DonDatHang, "MaDonHang", "MaKH", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: Admin/ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (ModelState.IsValid)
            {
                chiTietDonHang.IsDelet = true;
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
