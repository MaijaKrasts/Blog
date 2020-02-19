using Blog.Data.Db;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Blog.Data.Base
{
    public abstract class BaseRepository<T>
        where T : BaseData
    {
        protected BlogDb _db;

        protected abstract DbSet<T> Table { get; }

        public BaseRepository(BlogDb db)
        {
            _db = db;
        }

        public T Get(int id)
        {
            return Table.FirstOrDefault(i => i.Id == id);
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T Create(T data)
        {
            Table.Add(data);
            _db.SaveChanges();

            return data;
        }

        public void Update(T data)
        {
            Table.AddOrUpdate(data);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Table.FirstOrDefault(i => i.Id == id);
            Table.Remove(item);

            _db.SaveChanges();
        }
    }
}
