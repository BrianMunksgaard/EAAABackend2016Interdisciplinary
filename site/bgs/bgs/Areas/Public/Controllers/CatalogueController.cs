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
    /// <summary>
    /// Catalogue controller used to retrieve and display 
    /// products.
    /// </summary>
    public class CatalogueController : Controller
    {
        private UnitOfWork uow;
        /// <summary>
        /// Products per page.
        /// </summary>
        private int PageSize = 4;

        public CatalogueController()
        {
            uow = new UnitOfWork();
        }

        /// <summary>
        /// Catalogue co
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(string categoryCode = "q", int page = 1)
        {
            List<Product> products = uow.ProductRepository.GetProducts(categoryCode, page, PageSize);

            ProductListViewModel model = new ProductListViewModel
            {
                Products = products,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = uow.ProductRepository.GetProductCount(categoryCode)
                },

                CurrentCategory = uow.CategoryRepository.GetCategoryByCode(categoryCode)
            };

            return View(model);
        }
    }
}
