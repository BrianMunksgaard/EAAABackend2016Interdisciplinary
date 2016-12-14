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
            Game g = new Game();
            g.GameId = 123;
            int i = g.EntityId;

            SleeveSize s = new SleeveSize();
            s.ProductSizeId = 987;
            i = s.EntityId;

            return View();
        }
    }
}