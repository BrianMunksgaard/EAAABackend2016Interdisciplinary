using bgs.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace bgs.DAL
{
    /// <summary>
    /// Repository class for game/product relationships.
    /// </summary>
    public class ProductGameRepository
    {
        /// <summary>
        /// DB reference.
        /// </summary>
        private BgsContext db;

        /// <summary>
        /// Current type DB set.
        /// </summary>
        private DbSet<ProductFitGame> dbSet;

        /// <summary>
        /// Whether or not to save changes on update/delete/add operations.
        /// If false, the caller should take care of saving.
        /// </summary>
        protected bool saveChanges = false;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProductGameRepository() : this(new BgsContext(), true)
        {

        }

        /// <summary>
        /// Initializing the repository.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="saveChanges"></param>
        public ProductGameRepository(BgsContext db, bool saveChanges = true)
        {
            this.db = db;
            this.saveChanges = saveChanges;
            dbSet = db.Set<ProductFitGame>();
        }

        /// <summary>
        /// This method will delete a relation based on the data in the <paramref name="obj"/> parameter.
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

        /// <summary>
        /// Returns the Game/Product relations for the 
        /// game specified by <paramref name="gameId"/>.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public IList<ProductFitGame> GetItems(int gameId)
        {
            IQueryable<ProductFitGame> query = dbSet.Where(o => o.GameId == gameId);
            return query.ToList<ProductFitGame>();
        }

        /// <summary>
        /// This method will save the Game/Product relationship 
        /// but will ignore any updates to a relationship.
        /// </summary>
        /// <param name="t"></param>
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