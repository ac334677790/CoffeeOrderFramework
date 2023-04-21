using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class Order_dListViewModel
    {
        public IPagedList<Order_d> Order_ds { get; set; }
        //public int PageIndex { get; set; }
        
        public Dictionary<string, string> CodeOrderStatus { get; set; }

        public Dictionary<string, string> CodeSize { get; set; }

        public Dictionary<string, string> CodeSugar { get; set; }

        public Dictionary<string, string> CodeTemperature { get; set; }

        public Dictionary<string, string> CodeUnit { get; set; }

        public Dictionary<string, string> CodeDataStatus { get; set; }

        public Dictionary<string, string> CodeEndCode { get; set; }

    }

}