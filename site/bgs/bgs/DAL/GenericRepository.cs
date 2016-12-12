using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace bgs.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private BgsContext db;
        private DbSet<T> dbSet;

        public GenericRepository() : this(new BgsContext())
        {

        }

        public GenericRepository(BgsContext context)
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
            // NB: In this type of implementation it is difficult to check for the ID 
            //      when that property is named differently from class to class!

            //if (t.ProductId == 0)
            //{
            //    dbSet.Add(t);
            //    db.SaveChanges();
            //}
            //else
            //{
            //    db.Entry(t).State = EntityState.Modified;
            //    db.SaveChanges();
            //}
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