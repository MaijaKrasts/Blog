using System.Data.Entity;
using Blog.Data.Base;
using Blog.Data.Db;
using Blog.Data.Entities;
using Blog.Data.Repositories.Interfaces;

namespace Blog.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDb db)
            : base(db)
        {

        }

        protected override DbSet<Comment> Table
        {
            get
            {
                return _db.Comment;

            }
        }
    }
}
