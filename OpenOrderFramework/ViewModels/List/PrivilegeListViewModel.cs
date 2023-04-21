using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class PrivilegeListViewModel
    {
        public PrivilegeSearchModel SearchParameter { get; set; }

        public Privilege Privileges { get; set; }

        public UserGroup_m UserGroup_m { get; set; }

        public IPagedList<PrivilegeUserGroupViewModel> GroupID { get; set; }

        public SelectList GroupIDs { get; set; }        

        public int PageIndex { get; set; }

        public Dictionary<string, string> UserGroupDOC { get; set; }

    }

}