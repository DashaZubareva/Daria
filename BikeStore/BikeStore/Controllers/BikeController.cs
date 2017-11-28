using BikeStore.DataAccess;
using BikeStore.Enums;
using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ut = BikeStore.Utils.Utils;

namespace BikeStore.Controllers
{
    public class BikeController : Controller
    {
        BikeRepository bk = new BikeRepository();
        EnumCategory em = new EnumCategory();
        private string errorMessage = "";

        [HttpGet]
        public ActionResult SimpleList()
        {
            ViewBag.category = em;
            return View(bk.FindAll());
        }
        [HttpPost]
        public ActionResult SimpleList(IList<Bike> bikes)
        {
            return View(bikes);
        }
        public ActionResult EditBike(int? bikekId, string errorMessage)
        {
            int id = ut.GetInt(bikekId);
            if (id > 0)
            {
                ViewBag.ErrorMessage = errorMessage;
                Bike bookModel = bk.findBike(id);
                return View(bookModel);
            }
            else
            {//TODO:change to displaying message
                return RedirectToAction("List");
            }

        }
        [HttpPost]
        public ActionResult UpdateBook(Bike model)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = bk.update(model);
                errorMessage = "";
                //todo:display success message
                return RedirectToAction("SimpleList");
            }
            else
            {
                return RedirectToAction("EditBook", new
                {
                    bikekId = model.BikeId,
                    errorMessage = "Error in form book"
                });
            }
        }
        [HttpPost]
        public string DeleteBook(int? bikekId)
        {
            string statusCode = "0";
            int id = 0;
            if (int.TryParse("" + bikekId, out id))
            {
                ViewBag.ErrorMessage = errorMessage;
                bool isDeleted = bk.delete(id);
                return (isDeleted) ? "1" : "2";
            }
            else
            {
                return statusCode;

            }
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Bike model)
        {
            model.BikeId = new Random().Next(1000, 2000);
            if (ModelState.IsValid)
            {
                bk.addBook(model);
                return RedirectToAction("SimpleList");
            }
            else
            {
                errorMessage = "Error in form book";
                return RedirectToAction("AddBook");
            }
        }

        [HttpGet]
        public ActionResult SearchBooks(string val)
        {
            if (val == "")
            {
                ViewBag.message = "Value canot be empty";
                return RedirectToAction("SimpleLists");
            }
            else
            {
                IList<Bike> findedBikes = bk.searchBikes(val);
                return View(findedBikes);
            }
        }

    }
}