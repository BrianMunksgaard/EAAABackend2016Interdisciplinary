using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bgs.Areas.Public.Controllers
{
    /// <summary>
    /// This controller is used to create navigation ui elements
    /// for the application.
    /// </summary>
    public class NavController : Controller
    {
        /// <summary>
        /// This method is used to build a menu based
        /// on the current product categories.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Menu()
        {
            List<Category> categories = new List<Category>();

            return PartialView(categories);
        }
    }
}