using Blog.Data.Base;
using Blog.Data.Db;
using Blog.Data.Entities;
using System.Data.Entity;

namespace Blog.Data.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {

        public ArticleRepository(BlogDb db)
            : base(db)
        {
        }

        protected override DbSet<Article> Table
        {
            get
            {
                return _db.Article;
            }
        }
    }
}
