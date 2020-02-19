using Blog.Data.Entities;
using System.Data.Entity;

namespace Blog.Data.Db
{
    public class BlogDb : DbContext
    {
        public BlogDb(DbContext)
            : base()
        {

        }

        public DbSet<Article> Article { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Comment> Comment { get; set; }

    }
}
