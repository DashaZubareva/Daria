using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public ActionResult About()
        {
            AboutModel aboutModel = new AboutModel();
            aboutModel.Message = "About my site";

            ViewBag.DariaDate = DateTime.Now;

            return View(aboutModel);
        }
        public ActionResult aboutForm (AboutModel model)
        {
           // if (ModelState.IsValid)
          //  {
                return PartialView();
           // }
            
        }
       

    }
}