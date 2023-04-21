using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenOrderFramework.Models
{
    public partial class OrderItems
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        string OrderNo { get; set; }
        public const string OrderSessionKey = "OrderNo";
        public List<Order_m> GetOrderItems()
        {
            return storeDB.Order_ms.ToList();
        }


    }
}