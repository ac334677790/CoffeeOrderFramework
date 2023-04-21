using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class DepartmentListViewModel
    {
        public DepartmentSearchModel SearchParameter { get; set; }

        public IPagedList<Department> Departments { get; set; }

        public SelectList DeptIDs { get; set; }        

        public int PageIndex { get; set; }

        public Dictionary<string, string> Department { get; set; }

        public Dictionary<string, string> Employees { get; set; } 

        
    }

}