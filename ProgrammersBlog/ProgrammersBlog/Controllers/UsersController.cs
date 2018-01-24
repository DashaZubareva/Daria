using ProgrammersBlogDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProgrammersBlog.Models
{
    public class UsersController : Controller
    {
        private ProgrammersBlogContext db = new ProgrammersBlogContext();
       
        
        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            var userModels = new List<UserModel>();
            foreach(var user in users)
            {
                var tempUser = AutoMapper.Mapper.Map<User, UserModel>(user);
                userModels.Add(tempUser);
            }
                
            return View(userModels);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            User user = db.Users.Find(id);           
          //  user.Roles = db.UsersRoles.Where(item =>item.UserId == id).ToList();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,EMail,Birthday,Avatar,Password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user = AutoMapper.Mapper.Map<UserModel, User>(userModel);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userModel);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Include(p => p.Roles).Single(p => p.UserId == id);

            var muser = AutoMapper.Mapper.Map<User, UserModel>(user);

            return View(muser);
        }

        // POST: Users/Edit/5      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,EMail,Birthday,Avatar,Password")] UserModel userModel, HttpPostedFileBase userPhoto)
        {
            if (ModelState.IsValid)
            {
                if (userPhoto != null && userPhoto.ContentLength > 0)
                {
                    var avatar = new byte[userPhoto.ContentLength];
                    userPhoto.InputStream.Read(avatar, 0, userPhoto.ContentLength);
                    var base64 = Convert.ToBase64String(avatar);
                    var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                    userModel.Avatar = imgsrc;

                }
                User user = new User();
                user = AutoMapper.Mapper.Map<UserModel, User>(userModel);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
