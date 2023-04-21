using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class CompanyListViewModel
    {
        public CompanySearchModel SearchParameter { get; set; }

        public IPagedList<Company> Companys { get; set; }

        public SelectList CompanyIDs { get; set; }

        public int PageIndex { get; set; }

    }

}