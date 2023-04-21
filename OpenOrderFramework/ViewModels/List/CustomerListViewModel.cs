using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class CustomerListViewModel
    {
        public CustomerSearchModel SearchParameter { get; set; }

        public IPagedList<Customer> Customers { get; set; }

        public SelectList SexType { get; set; }

        public SelectList CustLevel { get; set; }

        public SelectList CustType { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<string, string> CodeYN { get; set; }

        public Dictionary<string, string> CodeSex { get; set; }

        public Dictionary<string, string> CodeCustLevel { get; set; }

        public Dictionary<string, string> CodeCustType { get; set; }

        public Dictionary<string, string> CodeOccupation { get; set; }
    }

}