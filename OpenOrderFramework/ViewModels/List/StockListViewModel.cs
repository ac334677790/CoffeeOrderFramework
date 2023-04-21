using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class StockListViewModel
    {
        public StockSearchModel SearchParameter { get; set; }

        public IPagedList<Stock> Stocks { get; set; }

        public int PageIndex { get; set; }

    }

}