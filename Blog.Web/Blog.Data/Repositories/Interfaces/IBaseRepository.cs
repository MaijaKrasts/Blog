using System.Collections.Generic;

namespace Blog.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Get(int id);

        List<T> GetAll();

        T Create(T data);

        void Update(T data);

        void Delete(int id);
    }
}
