using Blog.Data.Base;
using System;

namespace Blog.Data.Entities
{
    public class Comment : BaseData
    {
        public int AuthorId { get; set; }

        public int ArticleId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Reported { get; set; }
    }
}
