using DemoMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Intro(int id)
        {
            UserModel userModel = new UserModel();
            userModel.ID = id;
            userModel.Name = "Vasia";
            userModel.Age = 25;

            ViewBag.DariaDate = DateTime.Now;
            return View(userModel);
        }


        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult About()
        {
            return Redirect("/About/About");
        }
        public ActionResult displayAll()
        {
            IList countries = new ArrayList();
            countries.Add("Moldova");
            countries.Add("Russia");
            countries.Add("Usa");
            ViewBag.CountryList = countries;
            return View();
        }
       
    }
}