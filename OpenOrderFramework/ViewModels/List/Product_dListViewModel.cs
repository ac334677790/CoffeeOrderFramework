using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class Product_dListViewModel
    {
        public IPagedList<Product_d> Product_ds { get; set; }
        public Dictionary<string, string> CodeSize { get; set; }

        public Dictionary<string, string> CodeTemperature { get; set; }

    }

}