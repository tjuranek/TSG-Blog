using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSG_Blog.Models;

namespace TSG_Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            var db = ApplicationDbContext.Create();

            return View(db.Posts.Where(p => p.IsDraft == false).OrderByDescending(p => p.Date).ToList());
        }

        // GET: Create Post
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Post Form Submission
        [HttpPost]
        [Authorize]
        public ActionResult Create(Post post)
        {
            post.Date = DateTime.Now;
            post.IsDraft = true;

            var db = ApplicationDbContext.Create();
            db.Posts.Add(post);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Users = "author@blog.com")]
        public ActionResult Drafts()
        {
            var db = ApplicationDbContext.Create();

            return View(db.Posts.Where(p => p.IsDraft == true).OrderByDescending(p => p.Date).ToList());
        }

        [HttpGet]
        [Authorize(Users = "author@blog.com")]
        public ActionResult GoLive(int postId)
        {
            var db = ApplicationDbContext.Create();

            var postToRemove = db.Posts.FirstOrDefault(p => p.PostId == postId);

            db.Posts.Remove(postToRemove);
            db.SaveChanges();

            postToRemove.IsDraft = false;

            db.Posts.Add(postToRemove);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}