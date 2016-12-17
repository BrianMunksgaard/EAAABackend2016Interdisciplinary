using bgs.DAL;
using bgs.Models;
using System.Linq;
using System.Web.Mvc;

namespace bgs.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        //UnitOfWork uow = new UnitOfWork();

        // GET: Public/Home
        public ActionResult Index()
        {
          return RedirectToAction("Index", "Catalogue", new { area = "Public" });
        }
    }
}