using bgs.DAL;
using bgs.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bgs.Areas.Admin.Controllers
{
    public class ProductFitGamesController : Controller
    {
        private UnitOfWork uow;

        public ProductFitGamesController()
        {
            uow = new UnitOfWork();
        }

        // GET: Admin/ProductFitGames
        public ActionResult Index()
        {
            // TODO: Remove this. It is not used!
            var productGames = uow.ProductGameRepository.GetItems().AsQueryable().Include(p => p.Game).Include(p => p.Product);
            return View(productGames.ToList());
        }

        // GET: Admin/ProductFitGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFitGame productFitGame = uow.ProductGameRepository.GetItem(id ?? 0);
            if (productFitGame == null)
            {
                return HttpNotFound();
            }
            return View(productFitGame);
        }

        // GET: Admin/ProductFitGames/Create
        public ActionResult Create(int id)
        {
            ViewBag.Game = uow.GameRepository.GetItem(id);
            ViewBag.ProductId = new SelectList(uow.ProductRepository.GetItems(), "ProductId", "ProductName");
            return View();
        }

        // POST: Admin/ProductFitGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,GameId,Comment")] ProductFitGame productFitGame)
        {
            if (ModelState.IsValid)
            {
                uow.ProductGameRepository.SaveItem(productFitGame);
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(uow.GameRepository.GetItems(), "GameId", "GameName", productFitGame.GameId);
            ViewBag.ProductId = new SelectList(uow.ProductRepository.GetItems(), "ProductId", "ProductName", productFitGame.ProductId);
            return View(productFitGame);
        }

        // GET: Admin/ProductFitGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFitGame productFitGame = uow.ProductGameRepository.GetItem(id ?? 0);
            if (productFitGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(uow.GameRepository.GetItems(), "GameId", "GameName", productFitGame.GameId);
            ViewBag.ProductId = new SelectList(uow.ProductRepository.GetItems(), "ProductId", "ProductName", productFitGame.ProductId);
            return View(productFitGame);
        }

        // POST: Admin/ProductFitGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,GameId,Comment")] ProductFitGame productFitGame)
        {
            if (ModelState.IsValid)
            {
                uow.ProductGameRepository.SaveItem(productFitGame);
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(uow.GameRepository.GetItems(), "GameId", "GameName", productFitGame.GameId);
            ViewBag.ProductId = new SelectList(uow.ProductRepository.GetItems(), "ProductId", "ProductName", productFitGame.ProductId);
            return View(productFitGame);
        }

        // GET: Admin/ProductFitGames/Delete/5
        public ActionResult Delete(int gameId, int productId)
        {
            ProductFitGame productFitGame = uow.ProductGameRepository.GetItems().AsQueryable().Where(o => o.GameId == gameId && o.ProductId == productId).FirstOrDefault();
            if (productFitGame == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Details", "Games", new { id = gameId });
            //return View(productFitGame);
        }

        // POST: Admin/ProductFitGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uow.ProductGameRepository.DeleteItem(id);
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
