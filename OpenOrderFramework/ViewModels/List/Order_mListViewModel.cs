using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class Order_mListViewModel
    {
        public Order_mSearchModel SearchParameter { get; set; }

        public IPagedList<Order_mViewModel> Order_ms { get; set; }
        public Order_m order_m;
        //public IPagedList<Order_d> Order_ds { get; set; }
        public decimal total { get; set; }
        public int PageIndex { get; set; }

        public SelectList DataStatuses { get; set; }

        public Dictionary<string, string> CodePayment { get; set; }

        public Dictionary<string, string> CodeOrderDataStatus { get; set; }

        public Dictionary<string, string> Product { get; set; }

        public Dictionary<string, string> CodeOrderStatus { get; set; }

        public Dictionary<string, string> CodeSize { get; set; }

        public Dictionary<string, string> CodeSugar { get; set; }

        public Dictionary<string, string> CodeTemperature { get; set; }

        public Dictionary<string, string> CodeUnit { get; set; }

        public Dictionary<string, string> CodeDataStatus { get; set; }

        public Dictionary<string, string> CodeEndCode { get; set; }

    }

}