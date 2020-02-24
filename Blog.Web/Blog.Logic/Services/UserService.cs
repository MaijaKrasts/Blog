using Blog.Data.Entities.Services.Interfaces;
using Blog.Data.Repositories.Interfaces;
using Blog.Logic.Const.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace Blog.Data.Entities.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Create(user);
        }
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
        public User GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAllCommenting()
        {
            return _userRepository.GetAll()
                .Where(u => u.CanComment == Values.One)
                .ToList();
        }

        public List<User> GetAllRating()
        {
            return _userRepository.GetAll()
                .Where(u => u.CanRate == Values.One)
                .ToList();
        }

        public List<User> GetAllWriting()
        {
            return _userRepository.GetAll()
                .Where(u => u.CanWrite == Values.One)
                .ToList();
        }

        public List<User> GetAllAdmins()
        {
            return _userRepository
                .GetAll()
                .Where(u => u.Role == Values.One)
                .ToList();
        }

        public string SavePassword(string unhashedPassword)
        {
            return Crypto.HashPassword(unhashedPassword);
        }

        public bool CheckPasswordByEmail(string email, string unhashedPassword)
        {
            var user = GetByEmail(email);
            if (user != null)
            {
                string savedHashedPassword = user.Password;
                return Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword);
            }
            else return false;
        }

        public User UpdateUserCanWriteStatuss(string email)
        {
            var user = GetByEmail(email);
            user.CanWrite = Values.One;
            _userRepository.Update(user);

            return user;
        }

        public User UpdateUserCanCommentStatuss(string email)
        {
            var user = GetByEmail(email);
            if (user != null)
            {
                user.CanComment = Values.One;
                _userRepository.Update(user);
            }

            return user;
        }

        public User UpdateUserCanRateStatuss(string email)
        {
            var user = GetByEmail(email);
            if (user != null)
            {
                user.CanRate = Values.One;
                _userRepository.Update(user);
            }

            return user;
        }

        public User UpdateUserCanWriteStatussId(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                user.CanWrite = Values.One;
                _userRepository.Update(user);
            }
            return user;
        }

    }
}
