using BikeStore.DataAccess;
using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class BikeController : Controller
    {
        BikeRepository bk = new BikeRepository();
        // GET: Bike
        public ActionResult BikeList1()
        {
            ViewBag.selectList = null;
            IEnumerable<Bike> bikes = bk.FindAll();
            return View(bikes);
        }
    }
}