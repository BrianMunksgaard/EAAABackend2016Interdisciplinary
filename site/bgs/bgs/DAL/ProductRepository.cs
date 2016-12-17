using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.DAL
{
    /// <summary>
    /// Repository class for products.
    /// </summary>
    public class ProductRepository : Repository<Product>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="saveChanges"></param>
        public ProductRepository(BgsContext db, bool saveChanges = true) : base(db, saveChanges)
        {
        }

        /// <summary>
        /// Retrieve all products in the specified category or retrieve
        /// a subset/page of all products in the specified category.
        /// </summary>
        /// <param name="categoryCode">If null or empty, all products are retrieved.</param>
        /// <param name="currentPage">The current page if paging is used.</param>
        /// <param name="pageSize">The size of the page. 0 = No paging, retrieve all.</param>
        /// <returns></returns>
        public List<Product> GetProducts(string categoryCode, int currentPage = 0, int pageSize = 0)
        {
            List<Product> products = new List<Product>();

            // If no category code specified retrieve all products.
            if (string.IsNullOrEmpty(categoryCode))
            {
                products = GetProducts(currentPage, pageSize);
            }
            else // Retrieve products by category.
            {
                Category category = db.ProductCategories.SingleOrDefault(c => c.CategoryCode == categoryCode);
                if(category == null) // Category not found?
                {
                    products = new List<Product>();
                }
                else
                {
                    if (pageSize == 0)
                    {
                        products = db.Products.Where(p => p.CategoryId == category.CategoryId).OrderBy(p => p.ProductId).ToList(); ;
                    }
                    else
                    {
                        products = db.Products.Where(p => p.CategoryId == category.CategoryId).OrderBy(p => p.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                    }
                }
            }

            return products;
        }

        /// <summary>
        /// Retrieve all products (on pageSize = 0) or a subset/page of all products.
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Product> GetProducts(int currentPage = 0, int pageSize = 0)
        {
            List<Product> products = new List<Product>();
            if (pageSize == 0)
            {
                products = db.Products.OrderBy(p => p.ProductId).ToList();
            }
            else
            {
                products = db.Products.OrderBy(p => p.ProductId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            return products;
        }


        /// <summary>
        /// Retrieve product count of all products or of all
        /// products in the specified category.
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public int GetProductCount(string categoryCode = "")
        {
            if (string.IsNullOrEmpty(categoryCode))
            {
                return db.Products.Count();
            }
            else
            {
                Category category = db.ProductCategories.SingleOrDefault(c => c.CategoryCode == categoryCode);
                if(category == null)
                {
                    return 0;
                }
                else
                {
                    return db.Products.Where(p => p.CategoryId == category.CategoryId).Count();
                }
            }
        }
    }
}