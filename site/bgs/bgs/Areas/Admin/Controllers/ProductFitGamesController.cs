using bgs.DAL;
using bgs.Models;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Admin/ProductFitGames/Create
        public ActionResult Create(int id)
        {
            // Restrict the list to only include those that are not already in the list
            Game g = uow.GameRepository.GetItem(id);
            List<Product> possibleRelations = GetPossibleProductrelations(g);

            ViewBag.Game = g;
            ViewBag.ProductId = new SelectList(possibleRelations, "ProductId", "ProductName");
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
                return RedirectToAction("Details", "Games", new { id = productFitGame.GameId });
            }

            return RedirectToAction("Details", "Games", new { id = productFitGame.GameId });
        }

        // GET: Admin/ProductFitGames/Delete/5
        public ActionResult Delete(int gameId, int productId)
        {
            ProductFitGame productFitGame = uow.ProductGameRepository.GetItems().AsQueryable().Where(o => o.GameId == gameId && o.ProductId == productId).FirstOrDefault();
            if (productFitGame == null)
            {
                return HttpNotFound();
            }
            uow.ProductGameRepository.DeleteItem(productFitGame);

            return RedirectToAction("Details", "Games", new { id = gameId });
            //return View(productFitGame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<Product> GetPossibleProductrelations(Game game)
        {
            var currrentList = new HashSet<int>(game.ProductsFit.Select(p => p.ProductId));
            var viewModel = new List<Product>();

            foreach (Product prod in uow.ProductRepository.GetItems())
            {
                if (!currrentList.Contains(prod.ProductId))
                {
                    viewModel.Add(prod);
                }
            }

            return viewModel;
        }
    }
}
