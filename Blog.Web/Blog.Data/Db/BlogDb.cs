using Blog.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Blog.Data.Db
{
    public class BlogDb : DbContext
    {
        public BlogDb()
            : base("BlogDb")
        {

        }

        public DbSet<Article> Article { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Comment> Comment { get; set; }

    }
}
