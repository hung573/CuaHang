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
    public class ProductsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Brand).Include(p => p.Category);
            return View(product.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.IDBrand = new SelectList(db.Brand, "ID", "Name");
            ViewBag.IDCategory = new SelectList(db.Category, "ID", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Cost,Desceiption,Details,Image,IsSeller,OnTop,IDCategory,IDBrand,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.IsDeleted = false;
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBrand = new SelectList(db.Brand, "ID", "Name", product.IDBrand);
            ViewBag.IDCategory = new SelectList(db.Category, "ID", "Name", product.IDCategory);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBrand = new SelectList(db.Brand, "ID", "Name", product.IDBrand);
            ViewBag.IDCategory = new SelectList(db.Category, "ID", "Name", product.IDCategory);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Cost,Desceiption,Details,Image,IsSeller,OnTop,IDCategory,IDBrand,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.IsDeleted = false;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBrand = new SelectList(db.Brand, "ID", "Name", product.IDBrand);
            ViewBag.IDCategory = new SelectList(db.Category, "ID", "Name", product.IDCategory);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            if (ModelState.IsValid)
            {
                product.IsDeleted = true;
                db.Entry(product).State = EntityState.Modified;
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
