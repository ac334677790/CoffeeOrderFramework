using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class UserGroup_dEditViewModel
    {
        public User users { get; set; }
        public STATE state { get; set; }

        public enum STATE
        {
            NOTHING,INSERT, MODIFY, DELETE
        }
    }

}