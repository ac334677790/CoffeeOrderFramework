using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class Order_mViewModel
    {
        public string CompanyID { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string CustomerID { get; set; }
        public string CustName { get; set; }
        public string FaxNumber { get; set; }
        public string ContactName { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string PayKind { get; set; }
        public string DeliveryAddress { get; set; }
        public string CheckUserID { get; set; }
        public string PayAccount { get; set; }
        public string AppleyAccount { get; set; }
        public string AccountNAME { get; set; }
        public string Memo { get; set; }
        public string DataStatus { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public string DeliveryUserID { get; set; }
        public string Promotional { get; set; }
        public string CreateUserID { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyUserID { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public decimal total { get; set; }

    }

}