using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class UserGroup_mListViewModel
    {
        public UserGroup_mSearchModel SearchParameter { get; set; }

        public IPagedList<UserGroup_m> UserGroup_ms { get; set; }

        public IPagedList<UserGroup_d> UserGroup_ds { get; set; }

        public SelectList GroupIDs { get; set; }

        public int PageIndex { get; set; }

    }

}