using bgs.Models;
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

        /// <summary>
        /// This method will remove the ProductFitGame object that is given as the parameter.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ProductFitGame DeleteItem(ProductFitGame obj)
        {
            if (obj != null)
            {
                dbSet.Remove(obj);
                if (saveChanges)
                {
                    db.SaveChanges();
                }
            }
            return obj;
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

        public void SaveItem(ProductFitGame t)
        {
            ProductFitGame pfg = db.ProductGames.Where(pg => pg.GameId == t.GameId && pg.ProductId == t.ProductId).FirstOrDefault();
            if (pfg == null)
            {
                // All okay
                dbSet.Add(t);
                if (saveChanges)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}