using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class SelectProductViewModel
    {
        public IPagedList<Product> Products { get; set; }

    }

}