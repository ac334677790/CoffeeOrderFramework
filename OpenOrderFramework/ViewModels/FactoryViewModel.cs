using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class FactoryListViewModel
    {
        public FactorySearchModel SearchParameter { get; set; }

        public IPagedList<Factory> Factorys { get; set; }

        public SelectList FactoryIDs { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<string, string> CodeFactoryLevel { get; set; }

        public Dictionary<string, string> CodeFactoryType { get; set; }
    }

}