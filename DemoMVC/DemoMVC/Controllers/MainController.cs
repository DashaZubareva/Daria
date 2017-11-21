using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public ActionResult Multiple()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Multiple(MultipleModel model)
        { 
            if (model.Number == 0)
            {
                return RedirectToAction("View1",new { number = model.Number});//method, controller
            }
            if (model.Number < 0)
            {
                Response.Redirect("~/View2/"+  model.Number);
            }
            ViewBag.rezult = model.Number * 10;
            return View();
        }
    /*    public ActionResult Dellim(MultipleModel model)
        {
           
            ViewBag.rezult = model.Number / 10;
            return View();
        }*/
        public ActionResult View1(int number)
        {

            ViewBag.rezult = number;
            return View();
        }
        public ActionResult View2(int number)
        {

            ViewBag.rezult = number;
            return View();
        }
    }
}