using bgs.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace bgs.DAL
{
    /// <summary>
    /// Generic repository class that can be used for CRUD operation
    /// on classes that inherits from the BgsEntity class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BgsEntity
    {
        /// <summary>
        /// DB reference.
        /// </summary>
        private BgsContext db;

        /// <summary>
        /// Current type DB set.
        /// </summary>
        private IDbSet<T> dbSet;

        /// <summary>
        /// Whether or not to save changes on update/delete/add operations.
        /// If false, the caller should take care of saving.
        /// </summary>
        private bool saveChanges = false;

        /// <summary>
        /// Intialize the repository class.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="saveChanges"></param>
        public Repository(BgsContext db, bool saveChanges = true)
        {
            this.db = db;
            this.saveChanges = saveChanges;
            dbSet = db.Set<T>();
        }

        /// <summary>
        /// Retrieve the item of type T identified by the id parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetItem(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return dbSet.Find(id);
        }

        /// <summary>
        /// Retrieve all items of type T.
        /// </summary>
        /// <returns></returns>
        public IList<T> GetItems()
        {
            IQueryable<T> query = dbSet;
            return query.ToList<T>();
        }

        /// <summary>
        /// Save the specified type T.
        /// </summary>
        /// <param name="t"></param>
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

        /// <summary>
        /// Retrieve, delete and return the item of type T identified
        /// by the id parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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