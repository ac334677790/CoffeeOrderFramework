using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class ProductKindListViewModel
    {
        public ProductKindSearchModel SearchParameter { get; set; }

        public IPagedList<ProductKind> ProductKinds { get; set; }

        public SelectList ProdKinds { get; set; }

        public int PageIndex { get; set; }

    }

}