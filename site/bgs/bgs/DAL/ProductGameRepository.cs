using bgs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace bgs.DAL
{
    public class ProductGameRepository : IRepository<ProductFitGame>
    {
        private BgsContext db;

        private DbSet<ProductFitGame> dbSet;

        /// <summary>
        /// Whether or not to save changes on update/delete/add operations.
        /// If false, the caller should take care of saving.
        /// </summary>
        protected bool saveChanges = false;

        public ProductGameRepository() : this(new BgsContext(), true)
        {

        }

        public ProductGameRepository(BgsContext db, bool saveChanges = true)
        {
            this.db = db;
            this.saveChanges = saveChanges;
            dbSet = db.Set<ProductFitGame>();
        }

        public ProductFitGame DeleteItem(int id)
        {
            ProductFitGame t = dbSet.Find(id);
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

        public ProductFitGame GetItem(int id)
        {
            return dbSet.Find(id);
        }

        public IList<ProductFitGame> GetItems()
        {
            IQueryable<ProductFitGame> query = dbSet;
            return query.ToList<ProductFitGame>();
        }

        public int SaveItem(ProductFitGame t)
        {
            throw new NotImplementedException();

            // TODO Check to see if the relation already exists
            //if (t.EntityId == 0)
            //{
            //    dbSet.Add(t);
            //    if (saveChanges)
            //    {
            //        db.SaveChanges();
            //    }
            //}
            //else
            //{
            //    db.Entry(t).State = EntityState.Modified;
            //    if (saveChanges)
            //    {
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}