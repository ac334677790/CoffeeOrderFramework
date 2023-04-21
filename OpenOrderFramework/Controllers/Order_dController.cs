using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;
using OpenOrderFramework.ViewModels;


namespace OpenOrderFramework.Controllers
{
    public class Order_dController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
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


        [Authorize]
        // GET: /Order_d/
        public ActionResult Index(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string OrderNo = splitid[1];
            ViewBag.OrderNo = OrderNo;
            ViewBag.CompanyID = CompanyID;
            var query = db.Order_ds.Where(x => x.OrderNo == OrderNo).OrderBy(x => x.OrderSeq);

            var model = new Order_dListViewModel
            {
                Order_ds = query.ToPagedList(1, 99),  
                CodeOrderStatus = GetAllCodeOrderStatus(),
                CodeSize = GetAllCodeSize(),
                CodeSugar = GetAllCodeSugar(),
                CodeTemperature = GetAllCodeTemperature(),
                CodeUnit = GetAllCodeUnit(),
                CodeDataStatus = GetAllCodeDataStatus(),
                CodeEndCode = GetAllCodeEndCode(),
                
            };
            return View(model);
        }

        // GET: /Order_d/Details/5
        public ActionResult Details(string id)
        {
            string[] splitid = id.Split(',');
            Order_d order_d = db.Order_ds.Find(splitid[0], splitid[1], splitid[2]);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (order_d == null)
            {
                return HttpNotFound();
            }
            return View(order_d);
        }

        // GET: /Order_d/Create
        public ActionResult Create(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string OrderNo = splitid[1];
            ViewBag.OrderNo = OrderNo;
            ViewBag.CompanyID = CompanyID;
            string OrderSeq = db.Order_ds.Where(x => x.OrderNo == OrderNo).Count().ToString().PadLeft(3, '0');
            ViewBag.OrderSeq = OrderSeq;

            GetDropDownList();



            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var products = this.GetAllProduct();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var product in products)
            {
                items.Add(new SelectListItem()
                {
                    Text = product.Value,
                    Value = product.Key
                });
            }
            ViewBag.ProductList = items;

            //下拉帶入ViewBag
            var CodeOrderStatuses = this.GetAllCodeOrderStatus();

            items = new List<SelectListItem>();
            foreach (var CodeOrderStatus in CodeOrderStatuses)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeOrderStatus.Value,
                    Value = CodeOrderStatus.Key
                });
            }
            ViewBag.CodeOrderStatuses = items;

            //下拉帶入ViewBag
            var CodeCodeSizes = this.GetAllCodeSize();

            items = new List<SelectListItem>();
            foreach (var CodeCodeSize in CodeCodeSizes)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeCodeSize.Value,
                    Value = CodeCodeSize.Key
                });
            }
            ViewBag.CodeSizes = items;

            //下拉帶入ViewBag
            var CodeSugars = this.GetAllCodeSugar();

            items = new List<SelectListItem>();
            foreach (var CodeSugar in CodeSugars)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeSugar.Value,
                    Value = CodeSugar.Key
                });
            }
            ViewBag.CodeSugars = items;

            //下拉帶入ViewBag
            var CodeTemperatures = this.GetAllCodeTemperature();

            items = new List<SelectListItem>();
            foreach (var CodeTemperature in CodeTemperatures)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeTemperature.Value,
                    Value = CodeTemperature.Key
                });
            }
            ViewBag.CodeTemperatures = items;

            //下拉帶入ViewBag
            var CodeUnits = this.GetAllCodeUnit();

            items = new List<SelectListItem>();
            foreach (var CodeUnit in CodeUnits)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeUnit.Value,
                    Value = CodeUnit.Key
                });
            }
            ViewBag.CodeUnits = items;

            //下拉帶入ViewBag
            var CodeDataStatuses = this.GetAllCodeDataStatus();

            items = new List<SelectListItem>();
            foreach (var CodeDataStatus in CodeDataStatuses)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeDataStatus.Value,
                    Value = CodeDataStatus.Key
                });
            }
            ViewBag.CodeDataStatuses = items;

            //下拉帶入ViewBag
            var CodeEndCodes = this.GetAllCodeEndCode();

            items = new List<SelectListItem>();
            foreach (var CodeEndCode in CodeEndCodes)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeEndCode.Value,
                    Value = CodeEndCode.Key
                });
            }
            ViewBag.CodeEndCodes = items;
        }

        // POST: /Order_d/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,OrderNo,OrderSeq,ProductID,ProdName,ProdSpec,Qty,ProdUnit,CostPrice,UnitPrice,Discount,Total,Memo,OrderStatus,DataStatus,EndCode_YN,Temperature,Sugar,Size,CreateUserID,ModifyUserID")] Order_d order_d)
        {
            order_d.CompanyID = "S1";
            order_d.CreateUserID = "ADMIN";
            order_d.CreateDateTime = DateTime.Now;
            order_d.ModifyUserID = "ADMIN";
            order_d.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Order_ds.Add(order_d);
                db.SaveChanges();
                return RedirectToAction("../Order_m/Index");
            }
            return View(order_d);
        }

        // GET: /Order_d/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();
            string[] splitid = id.Split(',');
            Order_d order_d = db.Order_ds.Find(splitid[0], splitid[1], splitid[2]);
            string CompanyID = splitid[0];
            string OrderNo = splitid[1];
            ViewBag.OrderNo = OrderNo;
            ViewBag.CompanyID = CompanyID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (order_d == null)
            {
                return HttpNotFound();
            }
            return View(order_d);
        }

        // POST: /Order_d/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,OrderNo,OrderSeq,QuoteNo,QuoteSeq,ProductID,ProdName,ProdSpec,Qty,ProdUnit,CostPrice,UnitPrice,Discount,Total,Memo,OrderStatus,DataStatus,EndCode_YN,Temperature,Sugar,Size,CreateUserID,CreateDateTime,ModifyUserID")] Order_d order_d)
        {
            order_d.ModifyUserID = "ADMIN";
            order_d.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(order_d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Order_m/Index");
            }
            return View(order_d);
        }

        // GET: /Order_d/Delete/5
        public ActionResult Delete(string id)
        {
            string[] splitid = id.Split(',');
            Order_d order_d = db.Order_ds.Find(splitid[0], splitid[1], splitid[2]);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (order_d == null)
            {
                return HttpNotFound();
            }
            return View(order_d);
        }

        // POST: /Order_d/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Order_d order_d = db.Order_ds.Find(splitid[0], splitid[1], splitid[2]);
            db.Order_ds.Remove(order_d);
            db.SaveChanges();
            return RedirectToAction("../Order_m/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
