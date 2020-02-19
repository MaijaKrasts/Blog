using Blog.Data.Base;
using System;

namespace Blog.Data.Entities
{
    public class Article : BaseData
    {
        public string Title { get; set; }

        public string Intro { get; set; }

        public string Text { get; set; }

        public string Picture { get; set; }

        public int AuthorId { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
