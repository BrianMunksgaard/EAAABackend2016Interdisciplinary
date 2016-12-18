using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.DAL
{
    /// <summary>
    /// Repository class for product categories.
    /// </summary>
    public class CategoryRepository : Repository<Category>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="saveChanges"></param>
        public CategoryRepository(BgsContext db, bool saveChanges = true) : base(db, saveChanges)
        {
        }

        /// <summary>
        /// Retrieve category by category code.
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public Category GetCategory(string categoryCode)
        {
            return db.ProductCategories.SingleOrDefault(c => c.CategoryCode == categoryCode);
        }
    }
}