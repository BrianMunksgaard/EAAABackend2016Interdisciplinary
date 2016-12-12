using bgs.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace bgs.Areas.Admin.Controllers
{
    public class NavController : Controller
    {
        UnitOfWork uow;

        // GET: Admin/Nav
        public PartialViewResult Menu()
        {
            uow = new UnitOfWork();

            ViewBag.SelectedCategory = "Sleeves";

            IEnumerable<string> categories = uow.CategoryRepository.GetItems()
                .Select(p => p.CategoryText)
                .Distinct()
                .OrderBy(p => p);

            return PartialView(categories);
        }
    }
}