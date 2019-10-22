using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSG_Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        [AllowHtml]
        public string HtmlContent { get; set; }
    }
}