using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Article
{
    public class UserArticleModel
    {
        public List<Data.Entities.Article> UserArticles { get; set; }

        public Data.Entities.User User { get; set; }
    }
}