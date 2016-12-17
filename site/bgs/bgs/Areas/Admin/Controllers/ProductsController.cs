using bgs.DAL;
using bgs.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bgs.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private UnitOfWork uow;

        public ProductsController()
        {
            ViewBag.SelectedCategory = "Products";
            uow = new UnitOfWork();
        }

        // GET: Admin/Products
        public ActionResult Index(string category)
        {
            ViewBag.SelectedSubCategory = category;
            var products = uow.ProductRepository.GetItems().AsQueryable().Include(p => p.Category).Include(p => p.ProductSize);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uow.ProductRepository.GetItem(id ?? 0);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create(string category)
        {
            ViewBag.SelectedSubCategory = category;
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText");
            ViewBag.ProductSizeId = new SelectList(uow.SleeveSizeRepository.GetItems(), "ProductSizeId", "ProductSizeText");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductCode,Price,CategoryId,ProductSizeId,Weight,Barcode,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                uow.ProductRepository.SaveItem(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText", product.CategoryId);
            ViewBag.ProductSizeId = new SelectList(uow.SleeveSizeRepository.GetItems(), "ProductSizeId", "ProductSizeText", product.ProductSizeId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uow.ProductRepository.GetItem(id ?? 0);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText", product.CategoryId);
            ViewBag.ProductSizeId = new SelectList(uow.SleeveSizeRepository.GetItems(), "ProductSizeId", "ProductSizeText", product.ProductSizeId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductCode,Price,CategoryId,ProductSizeId,Weight,Barcode,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                uow.ProductRepository.SaveItem(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText", product.CategoryId);
            ViewBag.ProductSizeId = new SelectList(uow.SleeveSizeRepository.GetItems(), "ProductSizeId", "ProductSizeText", product.ProductSizeId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uow.ProductRepository.GetItem(id ?? 0);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uow.ProductRepository.DeleteItem(id);
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
