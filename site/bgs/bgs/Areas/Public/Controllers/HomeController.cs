using bgs.DAL;
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
            BgsContext context = new BgsContext();
            int gamesCount = context.Games.Count();

            return View();
        }
    }
}