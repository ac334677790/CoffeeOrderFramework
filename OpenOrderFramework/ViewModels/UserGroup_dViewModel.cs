using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class UserGroup_dViewModel
    {
        public List<UserGroup_dEditViewModel> UserGroup_dEdit { get; set; }
    }

}