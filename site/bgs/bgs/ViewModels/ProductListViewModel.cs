using bgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.ViewModels
{
    public class ProductListViewModel
    {
        private Category currentCategory;

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
        public Category CurrentCategory
        {
            get
            {
                if(currentCategory == null)
                {
                    currentCategory = new Category()
                    {
                        CategoryId = 0,
                        CategoryCode = string.Empty,
                        CategoryText = string.Empty
                    };

                }
                return currentCategory;
            }
            set { currentCategory = value; }
        }
    }
}