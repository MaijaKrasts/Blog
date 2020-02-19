using Blog.Data.Entities;
using Blog.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Blog.Data.Entities.Services
{
    public class UserService
    {
        private IUserRepository _user;
        public UserService(IUserRepository user)
        {
            _user = user;
        }

        public User Get(int id)
        {
            return _user.Get(id);
        }

        public List<User> GetAll()
        {
            return _user.GetAll();
        }

        public void Update(User user)
        {
            _user.Update(user);
        }
        public User GetByEmailAndPassword(string email, string password)
        {
            return _user.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User GetByEmail(string email)
        {
            return _user.GetAll().FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAllCommenting()
        {
            return _user.GetAll().Where(u => u.CanComment == 1).ToList();
        }

        public List<User> GetAllRating()
        {
            return _user.GetAll().Where(u => u.CanRate == 1).ToList();
        }

        public List<User> GetAllWriting()
        {
            return _user.GetAll().Where(u => u.CanWrite == 1).ToList();
        }

        public List<User> GetAllAdmins()
        {
            return _user.GetAll().Where(u => u.Role == 1).ToList();
        }

        public string SavePassword(string unhashedPassword)
        {
            return Crypto.HashPassword(unhashedPassword);
        }

        public bool CheckPasswordByEmail(string email, string unhashedPassword)
        {
            var user = GetByEmail(email);
            string savedHashedPassword = user.Password;

            return Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword);
        }

        public User UpdateUserCanWriteStatuss(string email)
        {
            var user = GetByEmail(email);
            user.CanWrite = 1;
            _user.Update(user);

            return user;
        }

        public User UpdateUserCanCommentStatuss(string email)
        {
            var user = GetByEmail(email);
            user.CanComment = 1;
            _user.Update(user);

            return user;
        }

        public User UpdateUserCanRateStatuss(string email)
        {
            var user = GetByEmail(email);
            user.CanRate = 1;
            _user.Update(user);

            return user;
        }

        public User UpdateUserCanWriteStatussId(int id)
        {
            var user = _user.Get(id);
            user.CanWrite = 1;
            _user.Update(user);

            return user;
        }
    }
}
