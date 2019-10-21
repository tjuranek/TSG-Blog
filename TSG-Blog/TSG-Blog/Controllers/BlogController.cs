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

            return View(db.Posts.ToList());
        }

        // GET: Create Post
        [HttpGet]
        [Authorize(Users = "author@blog.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Post Form Submission
        [HttpPost]
        [Authorize(Users = "author@blog.com")]
        public ActionResult Create(Post post)
        {
            post.Date = DateTime.Now;

            var db = ApplicationDbContext.Create();
            db.Posts.Add(post);
            db.SaveChanges();

            return View("Index", db.Posts.ToList());
        }
    }
}