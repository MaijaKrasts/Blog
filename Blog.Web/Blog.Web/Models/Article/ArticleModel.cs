using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog.Web.Models.Article
{
    public class ArticleModel
    {
       
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        public string Intro { get; set; }

        [AllowHtml]
        [Required]
        public string Text { get; set; }

        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$")]
        public string Picture { get; set; }

        public int AuthorId { get; set; }
    }
}