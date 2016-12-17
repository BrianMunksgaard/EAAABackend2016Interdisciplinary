using bgs.DAL;
using bgs.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bgs.Areas.Admin.Controllers
{
    public class GamesController : Controller
    {
        private UnitOfWork uow;

        public GamesController()
        {
            ViewBag.SelectedCategory = "Games";
            uow = new UnitOfWork();
        }

        // GET: Admin/Games
        public ActionResult Index()
        {
            return View(uow.GameRepository.GetItems().ToList());
        }

        // GET: Admin/Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                //Game game = uow.GameRepository.GetItem(id ?? 0);
                Game game = uow.GameRepository.GetItems().AsQueryable().Where(g => g.GameId == id).Include(g => g.ProductsFit).FirstOrDefault();
                if (game == null)
                {
                    return HttpNotFound();
                }
                return View(game);
            }
        }

        // GET: Admin/Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,GameName,GameCode")] Game game)
        {
            if (ModelState.IsValid)
            {
                uow.GameRepository.SaveItem(game);
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Admin/Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = uow.GameRepository.GetItem(id ?? 0);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,GameName,GameCode")] Game game)
        {
            if (ModelState.IsValid)
            {
                uow.GameRepository.SaveItem(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = uow.GameRepository.GetItem(id ?? 0);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uow.GameRepository.DeleteItem(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
