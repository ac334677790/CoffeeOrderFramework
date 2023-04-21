using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class PrivilegeEditViewModel
    {
        public  Privilege privilege { get; set; }
        public string ProgDescription { get; set; }
        public string ParentProgramID { get; set; }
        
        public int ProgramOrder { get; set; }
        public int ParentProgramOrder { get; set; }
        public int IsModify { get; set; }
    }

}