using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenOrderFramework.Models;
using PagedList;
using OpenOrderFramework.ViewModels;

namespace OpenOrderFramework.Controllers
{
    public class Order_mController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
        private Dictionary<string, string> GetAllCodePayment()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Payment").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeOrderDataStatus()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "OrderDataStatus").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        //細項下拉字典
        private Dictionary<string, string> GetAllProduct()
        {
            var query = db.Products.OrderBy(x => x.ProductID);
            return query.ToDictionary(x => x.ProductID.ToString(), x => x.ProdName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeOrderStatus()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "OrderStatus").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeSize()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Size").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeSugar()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Sugar").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeTemperature()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Temperature").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeUnit()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Unit").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeDataStatus()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "DataStatus").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeEndCode()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "EndCode").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        private IEnumerable<Code> DataStatusList
        {
            get { return db.Codes.Where(x => x.Code_Kind == "OrderDataStatus").OrderBy(x => x.CodeID); }
        }

        //頁數
        private const int PageSize = 12;

        private IEnumerable<Order_m> Order_msList
        {
            get { return db.Order_ms.OrderBy(x => x.OrderNo); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Order_ms.Where(x => x.DataStatus == "N").OrderBy(x => x.OrderNo);

            int pageIndex = page < 1 ? 1 : page;


            var query2 = (from Om in db.Order_ms.Where(x => x.DataStatus == "N")
                          join Odg in
                              (
                                 from Od in db.Order_ds
                                 group Od by new { Od.CompanyID, Od.OrderNo } into g
                                 select new { OrderNo = g.Key.OrderNo, CompanyID = g.Key.CompanyID, total = g.Sum(x => x.Total) }
                              ) on new { CompanyID = Om.CompanyID, OrderNo = Om.OrderNo } equals new { CompanyID = Odg.CompanyID, OrderNo = Odg.OrderNo } into odg
                          from Odg in odg.DefaultIfEmpty()
                          select new Order_mViewModel
                          {
                              CompanyID = Om.CompanyID,
                              OrderNo = Om.OrderNo,
                              OrderDateTime = Om.OrderDateTime,
                              CustomerID = Om.CustomerID,
                              CustName = Om.CustName,
                              FaxNumber = Om.FaxNumber,
                              ContactName = Om.ContactName,
                              TelephoneNumber = Om.TelephoneNumber,
                              MobileNumber = Om.MobileNumber,
                              Email = Om.Email,
                              PayKind = Om.PayKind,
                              DeliveryAddress = Om.DeliveryAddress,
                              CheckUserID = Om.CheckUserID,
                              PayAccount = Om.PayAccount,
                              AppleyAccount = Om.AppleyAccount,
                              AccountNAME = Om.AccountNAME,
                              Memo = Om.Memo,
                              DataStatus = Om.DataStatus,
                              DeliveryDateTime = Om.DeliveryDateTime,
                              DeliveryUserID = Om.DeliveryUserID,
                              Promotional = Om.Promotional,
                              CreateUserID = Om.CreateUserID,
                              CreateDateTime = Om.CreateDateTime,
                              ModifyUserID = Om.ModifyUserID,
                              ModifyDateTime = Om.ModifyDateTime,
                              total = ((decimal?)Odg.total) ?? 0
                          }).ToList().OrderBy(x => int.Parse(x.OrderNo));
                                      //orderby Convert.ToInt32(Om.OrderNo)
            var model = new Order_mListViewModel
            {
                SearchParameter = new Order_mSearchModel(),
                PageIndex = pageIndex,
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Order_ms = query2.ToPagedList(pageIndex, PageSize),                
                CodePayment = GetAllCodePayment(),
                CodeOrderDataStatus = GetAllCodeOrderDataStatus(),
                Product = GetAllProduct(),
                CodeOrderStatus = GetAllCodeOrderStatus(),
                CodeSize = GetAllCodeSize(),
                CodeSugar = GetAllCodeSugar(),
                CodeTemperature = GetAllCodeTemperature(),
                CodeUnit = GetAllCodeUnit(),
                CodeDataStatus = GetAllCodeDataStatus(),
                CodeEndCode = GetAllCodeEndCode(),
                DataStatuses = new SelectList(this.DataStatusList, "CodeID", "CodeName", selectedValue: "N")
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Order_mListViewModel model)
        {
            var query = db.Order_ms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.OrderNo))
            {
                query = query.Where(
                    x => x.OrderNo.Contains(model.SearchParameter.OrderNo));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustomerID))
            {
                query = query.Where(
                    x => x.CustomerID.Contains(model.SearchParameter.CustomerID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustName))
            {
                query = query.Where(
                    x => x.CustName.Contains(model.SearchParameter.CustName));
            }
            //if (!string.IsNullOrWhiteSpace(model.SearchParameter.OrderDateTime))
            //{
            //    query = query.Where(
            //        x => x.OrderDateTime.Contains(model.SearchParameter.OrderDateTime));
            //}

            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.OrderNo))
            {
                query = query.Where(x => x.OrderNo.Contains(model.SearchParameter.OrderNo));

            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.DataStatus))
            {
                query = query.Where(x => x.DataStatus.Contains(model.SearchParameter.DataStatus));

            }

            query = query.OrderBy(x => x.OrderNo);
            
            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;
            var query2 = (from Om in db.Order_ms.Where(x => x.DataStatus == "N")
                          join Odg in
                              (
                                 from Od in db.Order_ds
                                 group Od by new { Od.CompanyID, Od.OrderNo } into g
                                 select new { OrderNo = g.Key.OrderNo, CompanyID = g.Key.CompanyID, total = g.Sum(x => x.Total) }
                              ) on new { CompanyID = Om.CompanyID, OrderNo = Om.OrderNo } equals new { CompanyID = Odg.CompanyID, OrderNo = Odg.OrderNo } into odg
                          from Odg in odg.DefaultIfEmpty()
                          orderby Om.CreateDateTime descending
                          select new Order_mViewModel
                          {
                              CompanyID = Om.CompanyID,
                              OrderNo = Om.OrderNo,
                              OrderDateTime = Om.OrderDateTime,
                              CustomerID = Om.CustomerID,
                              CustName = Om.CustName,
                              FaxNumber = Om.FaxNumber,
                              ContactName = Om.ContactName,
                              TelephoneNumber = Om.TelephoneNumber,
                              MobileNumber = Om.MobileNumber,
                              Email = Om.Email,
                              PayKind = Om.PayKind,
                              DeliveryAddress = Om.DeliveryAddress,
                              CheckUserID = Om.CheckUserID,
                              PayAccount = Om.PayAccount,
                              AppleyAccount = Om.AppleyAccount,
                              AccountNAME = Om.AccountNAME,
                              Memo = Om.Memo,
                              DataStatus = Om.DataStatus,
                              DeliveryDateTime = Om.DeliveryDateTime,
                              DeliveryUserID = Om.DeliveryUserID,
                              Promotional = Om.Promotional,
                              CreateUserID = Om.CreateUserID,
                              CreateDateTime = Om.CreateDateTime,
                              ModifyUserID = Om.ModifyUserID,
                              ModifyDateTime = Om.ModifyDateTime,
                              total = ((decimal?)Odg.total) ?? 0
                          }).ToList();

            var result = new Order_mListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Order_ms = query2.ToPagedList(pageIndex, PageSize),
                
                CodePayment = GetAllCodePayment(),
                CodeOrderDataStatus = GetAllCodeOrderDataStatus(),
                Product = GetAllProduct(),
                CodeOrderStatus = GetAllCodeOrderStatus(),
                CodeSize = GetAllCodeSize(),
                CodeSugar = GetAllCodeSugar(),
                CodeTemperature = GetAllCodeTemperature(),
                CodeUnit = GetAllCodeUnit(),
                CodeDataStatus = GetAllCodeDataStatus(),
                CodeEndCode = GetAllCodeEndCode(),
                DataStatuses = new SelectList(this.DataStatusList, "CodeID", "CodeName" )
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Order_m/
        //public ActionResult Index()
        //{
        //    return View(db.Order_ms.ToList());
        //}

        // GET: /Order_m/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Order_m order_m = db.Order_ms.Find(splitid[0], splitid[1]);
            if (order_m == null)
            {
                return HttpNotFound();
            }
            return View(order_m);
        }

        // GET: /Order_m/Create
        public ActionResult Create()
        {
            GetDropDownList();
            
            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var CodePayments = this.GetAllCodePayment();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var CodePayment in CodePayments)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodePayment.Value,
                    Value = CodePayment.Key
                });
            }
            ViewBag.PayKinds = items;


            //下拉帶入ViewBag
            var CodeOrderDataStatuses = this.GetAllCodeOrderDataStatus();

            items = new List<SelectListItem>();
            foreach (var CodeOrderDataStatus in CodeOrderDataStatuses)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeOrderDataStatus.Value,
                    Value = CodeOrderDataStatus.Key,
                    Selected = CodeOrderDataStatus.Key.Equals("N")
                });
            }
            ViewBag.CodeOrderDataStatuses = items;
        }

        // POST: /Order_m/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,OrderNo,OrderDateTime,CustomerID,CustName,FaxNumber,ContactName,TelephoneNumber,MobileNumber,Email,PayKind,DeliveryAddress,CheckUserID,PayAccount,AppleyAccount,AccountNAME,Memo,DataStatus,DeliveryDateTime,DeliveryUserID,Promotional,CreateUserID,ModifyUserID")] Order_m order_m)
        {
            int temp2;
            int max2 = db.Order_ms.Select(x => x.OrderNo).ToList().Select(n => int.TryParse(n, out temp2) ? temp2 : 0).Max();
            order_m.OrderNo = (++max2).ToString();
            order_m.CompanyID = "S1";
            order_m.CreateUserID = "ADMIN";
            order_m.CreateDateTime = DateTime.Now;
            order_m.ModifyUserID = "ADMIN";
            order_m.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Order_ms.Add(order_m);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Create");
            }

            return View(order_m);
        }

        // GET: /Order_m/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Order_m order_m = db.Order_ms.Find(splitid[0], splitid[1]);
            if (order_m == null)
            {
                return HttpNotFound();
            }
            return View(order_m);
        }

        // POST: /Order_m/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,OrderNo,OrderDateTime,CustomerID,CustName,FaxNumber,ContactName,TelephoneNumber,MobileNumber,Email,PayKind,DeliveryAddress,CheckUserID,PayAccount,AppleyAccount,AccountNAME,Memo,DataStatus,DeliveryDateTime,DeliveryUserID,Promotional,CreateUserID,CreateDateTime,ModifyUserID")] Order_m order_m)
        {
            order_m.ModifyUserID = "ADMIN";
            order_m.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(order_m).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(order_m);
        }

        // GET: /Order_m/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Order_m order_m = db.Order_ms.Find(splitid[0], splitid[1]);
            if (order_m == null)
            {
                return HttpNotFound();
            }
            return View(order_m);
        }

        // POST: /Order_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Order_m order_m = db.Order_ms.Find(splitid[0], splitid[1]);
            db.Order_ms.Remove(order_m);


            //細項也要刪除
            string companyID = splitid[0];
            string orderNo = splitid[1];
            db.Order_ds.RemoveRange(db.Order_ds.Where(x => x.CompanyID == companyID && x.OrderNo == orderNo));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult RdlcReportDemo()
        {
            string aspx = "/ReportViewer.aspx";
            using (var sw = new System.IO.StringWriter())
            {
                System.Web.HttpContext.Current.Server.Execute(aspx, sw, true);
                return Content(sw.ToString());
            }
        }
    }
}
