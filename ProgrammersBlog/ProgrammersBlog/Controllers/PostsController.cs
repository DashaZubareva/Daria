using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgrammersBlog.Models;
using ProgrammersBlogDomain;

namespace ProgrammersBlog.Controllers
{
    public class PostsController : Controller
    {
        private ProgrammersBlogContext db = new ProgrammersBlogContext();
      
        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            var postModels = new List<PostModel>();

            foreach (var p in posts)
            {
                var pm = AutoMapper.Mapper.Map<Post, PostModel>(p);
                postModels.Add(pm);
            }
            return View(postModels);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Posts.Include(p => p.Comments).Single(p=>p.PostId==id);
            if (post == null)
            {
                return HttpNotFound();
            }
          //  post.Comments = db.Comments.Where(item => item.PostId == id).ToList();            
            var pm = AutoMapper.Mapper.Map<Post, PostModel>(post);           
            return View(pm);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Body,Deleted")] PostModel postModel)
        {
            var post = AutoMapper.Mapper.Map<PostModel, Post>(postModel) as Post;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Body,Deleted")] PostModel post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
        /****Comment Actions*****/
        [HttpPost]
       
        public PartialViewResult CreateComment(int postId, string commentBody, int userId = 1)
        {
            Post post = db.Posts.Include(p => p.Comments).Single(p =>p.PostId == postId);
            if (ModelState.IsValid)
            {
                post.Comments.Add(new Comment { PostId = postId, UserId = userId, BodyComments = commentBody });
                db.SaveChanges();
            }
            PostModel postModel = AutoMapper.Mapper.Map<Post, PostModel>(post);
          //  return RedirectToAction("Details/"+ postId.ToString());

            return PartialView("_PostComments", postModel);
        }
    }
}
