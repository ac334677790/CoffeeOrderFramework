using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class EmployeeListViewModel
    {
        public EmployeeSearchModel SearchParameter { get; set; }

        public IPagedList<Employee> Employees { get; set; }

        public SelectList EmpIDs { get; set; }

        public SelectList DeptIDs { get; set; }

        public SelectList PositionIDs { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<string, string> Department { get; set; }

        public Dictionary<string, string> Position { get; set; }

    }

}