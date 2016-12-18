using bgs.DAL;
using bgs.ViewModels;
using System.Web.Mvc;

namespace bgs.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork uow;

        // GET: Admin/Home
        public ActionResult Index(string category, int page = 1)
        {
            uow = new UnitOfWork();

            ProductListViewModel model = new ProductListViewModel
            {
                //Products = uow.
                //.Where(p => category == null || p.Category == category)
                //.OrderBy(p => p.ProductId)
                //.Skip((page - 1) * PageSize)
                //.Take(PageSize),

                //PagingInfo = new PagingInfo
                //{
                //    CurrentPage = page,
                //    ItemsPerPage = PageSize,
                //    TotalItems = category == null ?
                //        repo.Products.Count() :
                //        repo.Products.Where(p => p.Category == category).Count()
                //},
                CurrentCategory = uow.CategoryRepository.GetCategoryByCode(category)
            };

            return View(model);
        }
    }
}