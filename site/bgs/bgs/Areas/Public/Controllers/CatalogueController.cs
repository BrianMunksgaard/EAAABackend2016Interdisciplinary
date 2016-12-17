using bgs.DAL;
using bgs.Models;
using bgs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bgs.Areas.Public.Controllers
{
    public class CatalogueController : Controller
    {
        /// <summary>
        /// Products per page.
        /// </summary>
        private int PageSize = 4;

        // GET: Public/Catalogue
        public ActionResult Index(string categoryCode = "", int page = 1)
        {
            UnitOfWork uow = new UnitOfWork();

            Category category = null;
            if (!string.IsNullOrEmpty(categoryCode))
            {
                category = uow.CategoryRepository.GetItems().SingleOrDefault(c => c.CategoryCode == categoryCode);
            }

            List<Product> products = uow.ProductRepository.GetProductsByCategory(categoryCode, page, PageSize);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count
                },

                CurrentCategory = uow.CategoryRepository.GetCategoryByCode(categoryCode)
            };

            return View(model);
        }
    }
}

/*
       ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                
                CurrentCategory = category
            };

            return View(model);
*/
