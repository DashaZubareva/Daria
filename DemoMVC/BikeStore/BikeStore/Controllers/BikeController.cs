using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class BikeController : Controller
    {
        // GET: Bike
        public ActionResult Index()
        {
            return View();
        }
    }
}