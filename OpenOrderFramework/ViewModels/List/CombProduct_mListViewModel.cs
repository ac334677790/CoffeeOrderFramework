using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class CombProduct_mListViewModel
    {
        public CombProduct_mSearchModel SearchParameter { get; set; }

        public IPagedList<CombProduct_m> CombProduct_ms { get; set; }

        public IPagedList<CombProduct_d> CombProduct_ds { get; set; }

        public SelectList CombProductIDs { get; set; }

        public int PageIndex { get; set; }

    }

}