using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bgs.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Redirect to public area home controller.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Public" });
        }
    }
}