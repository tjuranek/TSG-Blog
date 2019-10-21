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

            db.Posts.Add(new Post()
            {
                Title = "Post Title",
                Date = DateTime.Now,
                Content = "Spicy jalapeno bacon ipsum dolor amet boudin bacon pork belly shoulder beef pastrami jowl, jerky shankle picanha doner alcatra cupim. Shankle capicola short loin buffalo. Shoulder strip steak fatback pork chop ham, picanha spare ribs pastrami andouille hamburger tenderloin. Ribeye biltong fatback leberkas filet mignon cow landjaeger strip steak tri-tip beef ribs. Sausage bacon rump pork belly beef filet mignon. Brisket short loin bresaola tri-tip."
            });

            db.SaveChanges();

            return View(db.Posts.ToList());
        }
    }
}