using System.Collections.Generic;

namespace Blog.Data.Entities.Services.Interfaces
{
    public interface IUserService
    {
        User Get(int id);
        List<User> GetAll();
        User Create(User user);
        void Update(User user);
        User GetByEmailAndPassword(string email, string password);
        User GetByEmail(string email);
        List<User> GetAllCommenting();
        List<User> GetAllRating();
        List<User> GetAllWriting();
        List<User> GetAllAdmins();
        string SavePassword(string unhashedPassword);
        bool CheckPasswordByEmail(string email, string unhashedPassword);
        User UpdateUserCanWriteStatuss(string email);
        User UpdateUserCanCommentStatuss(string email);
        User UpdateUserCanRateStatuss(string email);
        User UpdateUserCanWriteStatussId(int id);
    }
}
