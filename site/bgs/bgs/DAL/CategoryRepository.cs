using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.DAL
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(BgsContext db, bool saveChanges = true) : base(db, saveChanges)
        {
        }

        public Category GetCategoryByCode(string categoryCode)
        {
            return db.ProductCategories.SingleOrDefault(c => c.CategoryCode == categoryCode);
        }
    }
}