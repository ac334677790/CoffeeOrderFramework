using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class ParamListViewModel
    {
        public ParamSearchModel SearchParameter { get; set; }

        public IPagedList<Param> Params { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<string, string> CodeYN { get; set; }
    }

}