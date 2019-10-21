using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSG_Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}