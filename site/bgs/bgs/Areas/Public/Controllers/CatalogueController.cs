﻿using bgs.DAL;
using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bgs.Areas.Public.Controllers
{
    public class CatalogueController : Controller
    {
        // GET: Public/Catalogue
        public ActionResult Index()
        {
            UnitOfWork uow = new UnitOfWork();
            IList<Sleeve> sleeves = uow.SleeveRepository.GetItems();
            return View(sleeves);
        }
    }
}