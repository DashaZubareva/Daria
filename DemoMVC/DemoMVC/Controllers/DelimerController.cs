using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class DelimerController : Controller
    {
        // GET: Delimer
        public ActionResult Delimer(MultipleModel model)
        {
            ViewBag.rezult = model.Number / 2;
            return View();
           
        }
    }
}