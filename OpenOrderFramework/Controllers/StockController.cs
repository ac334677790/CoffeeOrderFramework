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
    public class StockController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Stock> StocksList
        {
            get { return db.Stocks.OrderBy(x => x.ProductID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Stocks.OrderBy(x => x.ProductID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new StockListViewModel
            {
                SearchParameter = new StockSearchModel(),
                PageIndex = pageIndex,
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Stocks = query.ToPagedList(pageIndex, PageSize)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(StockListViewModel model)
        {
            var query = db.Stocks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProductID))
            {
                query = query.Where(
                    x => x.ProductID.Contains(model.SearchParameter.ProductID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.BatNo))
            {
                query = query.Where(
                    x => x.BatNo.Contains(model.SearchParameter.BatNo));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProductID))
            {
                query = query.Where(x => x.ProductID.Contains(model.SearchParameter.ProductID));

            }

            query = query.OrderBy(x => x.ProductID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new StockListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Stocks = query.ToPagedList(pageIndex, PageSize)
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Stock/
        //public ActionResult Index()
        //{
        //    return View(db.Stocks.ToList());
        //}

        // GET: /Stock/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Stock stock = db.Stocks.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: /Stock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Stock/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,WarehouseID,ProductID,BatNo,InitQty,StockQty,LastTranDate,CreateUserID,ModifyUserID")] Stock stock)
        {
            stock.CompanyID = "S1";
            stock.CreateUserID = "ADMIN";
            stock.CreateDateTime = DateTime.Now;
            stock.ModifyUserID = "ADMIN";
            stock.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(stock);
        }

        // GET: /Stock/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Stock stock = db.Stocks.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: /Stock/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,WarehouseID,ProductID,BatNo,InitQty,StockQty,LastTranDate,CreateUserID,CreateDateTime,ModifyUserID")] Stock stock)
        {
            stock.ModifyUserID = "ADMIN";
            stock.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        // GET: /Stock/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Stock stock = db.Stocks.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: /Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Stock stock = db.Stocks.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            db.Stocks.Remove(stock);
            db.SaveChanges();
            TempData["save"] = "save";
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
    }
}
