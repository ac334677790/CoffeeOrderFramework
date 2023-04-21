using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class LongOrder_mListViewModel
    {
        public LongOrder_mSearchModel SearchParameter { get; set; }

        public IPagedList<LongOrder_m> LongOrder_ms { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<string, string> CodeOrderDataStatus { get; set; }
    }

}