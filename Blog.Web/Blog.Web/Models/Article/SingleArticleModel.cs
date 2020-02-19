using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Article
{
    public class SingleArticleModel
    {
        public Data.Entities.Article Article { get; set; }

        public List<Comment> Comments { get; set; }

        public string Comment { get; set; }

        public Data.Entities.User User { get; set; }

        public List<Data.Entities.User> Users { get; set; }
    }

}