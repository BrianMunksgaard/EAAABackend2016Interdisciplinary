using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bgs.Areas.Public.Controllers
{
    public class NavController : Controller
    {
        // GET: Public/Nav
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}