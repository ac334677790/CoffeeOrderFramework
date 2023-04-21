using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class UserListViewModel
    {
        public UserSearchModel SearchParameter { get; set; }

        public IPagedList<User> Users { get; set; }

        public SelectList UserIDs { get; set; }        

        public int PageIndex { get; set; }

        public Dictionary<string, string> Employees { get; set; }
    }

}