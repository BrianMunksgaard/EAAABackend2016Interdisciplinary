using bgs.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace bgs.DAL
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        private BgsContext db;
        private DbSet<T> dbSet;

        public ProductRepository()
            : this(new BgsContext())
        {
        }

        public ProductRepository(BgsContext context)
        {
            db = context;
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetItems()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetItem(int id)
        {
            return dbSet.Find(id);
        }

        public void SaveItem(T t)
        {
            if (t.ProductId == 0)
            {
                dbSet.Add(t);
                db.SaveChanges();
            }
            else
            {
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public T DeleteItem(int id)
        {
            T t = dbSet.Find(id);
            if (t != null)
            {
                dbSet.Remove(t);
                db.SaveChanges();
            }
            return t;

        }
    }
}