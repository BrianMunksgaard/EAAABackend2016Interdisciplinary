using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.ViewModels
{
    public class ProductListViewModel
    {

        /// <summary>
        /// All current products on the page.
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Page information.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }

        /// <summary>
        /// The currently selected product category.
        /// </summary>
        public Category CurrentCategory { get; set; }
    }
}