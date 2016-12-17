using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.DAL
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(BgsContext db, bool saveChanges = true) : base(db, saveChanges)
        {
        }

        public List<Product> GetProductsByCategory(string categoryCode, int currentPage = 0, int pageSize = 0)
        {
            Category category = db.ProductCategories.SingleOrDefault(c => c.CategoryCode == categoryCode);
            return GetProductsByCategory(category, currentPage, pageSize);
        }

        public List<Product> GetProductsByCategory(Category category, int currentPage = 0, int pageSize = 0)
        {
            List<Product> products = null;

            if (currentPage > 0)
            {
                products = db.Products.Where(p => p.CategoryId == category.CategoryId).OrderBy(p => p.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                products = db.Products.Where(p => p.CategoryId == category.CategoryId).OrderBy(p => p.ProductId).ToList();
            }

            return products;
        }
    }
}