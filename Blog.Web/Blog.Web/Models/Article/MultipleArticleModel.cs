﻿using System.Collections.Generic;

namespace Blog.Web.Models.Article
{
    public class MultipleArticleModel
    {
        public List<Data.Entities.Article> FewArticles { get; set; }

        public List<Data.Entities.Article> HighestRated { get; set; }

        public List<Data.Entities.Article> LastCommented { get; set; }

        public Data.Entities.Article LatestArticle { get; set; }
    }
}