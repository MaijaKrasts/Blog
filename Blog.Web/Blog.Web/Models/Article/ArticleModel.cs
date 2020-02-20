﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Article
{
    public class ArticleModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Intro { get; set; }

        [Required]
        public string Text { get; set; }

       // public IFormFile UpdatedPicture { get; set; }

        public string Picture { get; set; }

        public int AuthorId { get; set; }
    }
}