using bgs.DAL;
using bgs.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bgs.Areas.Admin.Controllers
{
    public class SleevesController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();
        private Repository<Sleeve> repo;

        public SleevesController()
        {
            repo = uow.SleeveRepository;
        }

        // GET: Admin/Sleeves
        public ActionResult Index()
        {
            var sleeves = repo.GetItems().AsQueryable().Include(s => s.Category);
            return View(sleeves.ToList());
        }

        // GET: Admin/Sleeves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleeve sleeve = repo.GetItem(id);
            if (sleeve == null)
            {
                return HttpNotFound();
            }
            return View(sleeve);
        }

        // GET: Admin/Sleeves/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText");
            return View();
        }

        // POST: Admin/Sleeves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductCode,Price,CategoryId,CategoryPropertiesId,Size,CMYK,RGB,Weight")] Sleeve sleeve)
        {
            if (ModelState.IsValid)
            {
                repo.SaveItem(sleeve);
                uow.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText", sleeve.CategoryId);
            return View(sleeve);
        }

        // GET: Admin/Sleeves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleeve sleeve = repo.GetItem(id);
            if (sleeve == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText", sleeve.CategoryId);
            return View(sleeve);
        }

        // POST: Admin/Sleeves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductCode,Price,CategoryId,CategoryPropertiesId,Size,CMYK,RGB,Weight")] Sleeve sleeve)
        {
            if (ModelState.IsValid)
            {
                repo.SaveItem(sleeve);
                uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetItems(), "CategoryId", "CategoryText", sleeve.CategoryId);
            return View(sleeve);
        }

        // GET: Admin/Sleeves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleeve sleeve = repo.GetItem(id);
            if (sleeve == null)
            {
                return HttpNotFound();
            }
            return View(sleeve);
        }

        // POST: Admin/Sleeves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteItem(id);
            uow.Save();
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
