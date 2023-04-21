using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class ProductListViewModel
    {
        public ProductSearchModel SearchParameter { get; set; }

        public IPagedList<Product> Products { get; set; }
        
        public SelectList ProductIDs { get; set; }

        public int PageIndex { get; set; }


        public Dictionary<string, string> ProductKind { get; set; }

        public Dictionary<string, string> Factory { get; set; }


        public Dictionary<string, string> CodeSize { get; set; }

        public Dictionary<string, string> CodeTemperature { get; set; }

    }

}