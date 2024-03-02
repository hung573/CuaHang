using CuaHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        DBContext db = new DBContext();
        public ActionResult Category()
        {
            return View();
        }
   
        public ActionResult ChiTiet(int id)
        {
            Product map = new Product();
            return View(map.ChiTiet(id));
        }
    }
}