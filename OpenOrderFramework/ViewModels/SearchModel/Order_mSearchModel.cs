using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenOrderFramework.ViewModels
{
    public class Order_mSearchModel
    {
        public string OrderNo { get; set; }

        public string OrderDateTime { get; set; }

        public string CustomerID { get; set; }

        public string CustName { get; set; }

        public string DataStatus { get; set; }
    }
}