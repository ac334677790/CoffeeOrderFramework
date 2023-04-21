using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class WarehouseListViewModel
    {
        public WarehouseSearchModel SearchParameter { get; set; }

        public IPagedList<Warehouse> Warehouses { get; set; }

        public SelectList WarehouseIDs { get; set; }

        public int PageIndex { get; set; }

    }

}