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
    public class ImageProductsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/ImageProducts
        public ActionResult Index()
        {
            var imageProduct = db.ImageProduct.Include(i => i.Product);
            return View(imageProduct.ToList());
        }

        // GET: Admin/ImageProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageProduct imageProduct = db.ImageProduct.Find(id);
            if (imageProduct == null)
            {
                return HttpNotFound();
            }   
            return View(imageProduct);
        }

        // GET: Admin/ImageProducts/Create
        public ActionResult Create()
        {

            ViewBag.IDProduct = new SelectList(db.Product, "ID", "Name");
            return View();
        }

        // POST: Admin/ImageProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Image,IDProduct")] ImageProduct imageProduct)
        {
            if (ModelState.IsValid)
            {
                
                db.ImageProduct.Add(imageProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProduct = new SelectList(db.Product, "ID", "Name", imageProduct.IDProduct);
            return View(imageProduct);
        }

        // GET: Admin/ImageProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageProduct imageProduct = db.ImageProduct.Find(id);
            if (imageProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProduct = new SelectList(db.Product, "ID", "Name", imageProduct.IDProduct);
            return View(imageProduct);
        }

        // POST: Admin/ImageProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,IDProduct")] ImageProduct imageProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProduct = new SelectList(db.Product, "ID", "Name", imageProduct.IDProduct);
            return View(imageProduct);
        }

        // GET: Admin/ImageProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageProduct imageProduct = db.ImageProduct.Find(id);
            if (imageProduct == null)
            {
                return HttpNotFound();
            }
            return View(imageProduct);
        }

        // POST: Admin/ImageProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageProduct imageProduct = db.ImageProduct.Find(id);
            db.ImageProduct.Remove(imageProduct);
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
