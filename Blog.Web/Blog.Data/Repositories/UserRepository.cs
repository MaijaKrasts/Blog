using Blog.Data.Base;
using Blog.Data.Db;
using Blog.Data.Entities;
using System.Data.Entity;

namespace Blog.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(BlogDb db)
            : base(db)
        {
        }

        protected override DbSet<User> Table
        {
            get
            {
                return _db.User;
            }
        }
    }
}
