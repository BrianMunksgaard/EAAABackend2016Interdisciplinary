using bgs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bgs.DAL
{
    /// <summary>
    /// Generic repository class that can be used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BgsEntity
    {
        private BgsContext db;
        private IDbSet<T> dbSet;
        private bool saveChanges = false;

        public Repository(BgsContext db)
        {
            this.db = db;
            this.saveChanges = true;
            dbSet = db.Set<T>();
        }

        public Repository(BgsContext db, bool saveChanges)
        {
            this.db = db;
            this.saveChanges = saveChanges;
            dbSet = db.Set<T>();
        }

        public T GetItem(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetItems()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void SaveItem(T t)
        {
            if (t.EntityId == 0)
            {
                dbSet.Add(t);
                if (saveChanges)
                {
                    db.SaveChanges();
                }
            }
            else
            {
                db.Entry(t).State = EntityState.Modified;
                if (saveChanges)
                {
                    db.SaveChanges();
                }
            }
        }

        public T DeleteItem(int id)
        {
            T t = dbSet.Find(id);
            if (t != null)
            {
                dbSet.Remove(t);
                if (saveChanges)
                {
                    db.SaveChanges();
                }
            }
            return t;

        }
    }
}