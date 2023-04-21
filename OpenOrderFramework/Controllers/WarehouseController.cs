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
    public class WarehouseController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Warehouse> WarehousesList
        {
            get { return db.Warehouses.OrderBy(x => x.WarehouseID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Warehouses.OrderBy(x => x.WarehouseID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new WarehouseListViewModel
            {
                SearchParameter = new WarehouseSearchModel(),
                PageIndex = pageIndex,
                WarehouseIDs = new SelectList(this.WarehousesList, "WarehouseID", "WarehouseName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Warehouses = query.ToPagedList(pageIndex, PageSize)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(WarehouseListViewModel model)
        {
            var query = db.Warehouses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.WarehouseID))
            {
                query = query.Where(
                    x => x.WarehouseID.Contains(model.SearchParameter.WarehouseID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.WarehouseName))
            {
                query = query.Where(
                    x => x.WarehouseName.Contains(model.SearchParameter.WarehouseName));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.WarehouseID))
            {
                query = query.Where(x => x.WarehouseID.Contains(model.SearchParameter.WarehouseID));

            }

            query = query.OrderBy(x => x.WarehouseID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new WarehouseListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                WarehouseIDs = new SelectList(
                    items: this.WarehousesList, dataValueField: "WarehouseID",
                    dataTextField: "WarehouseName",
                    selectedValue: model.SearchParameter.WarehouseID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Warehouses = query.ToPagedList(pageIndex, PageSize)
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Warehouse/
        //public ActionResult Index()
        //{
        //    return View(db.Warehouses.ToList());
        //}

        // GET: /Warehouse/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // GET: /Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Warehouse/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompanyID,WarehouseID,WarehouseName,PhoneNumber,WarehouseAddress,CreateUserID,ModifyUserID")] Warehouse warehouse)
        {
            warehouse.CompanyID = "S1";
            warehouse.CreateUserID = "ADMIN";
            warehouse.CreateDateTime = DateTime.Now;
            warehouse.ModifyUserID = "ADMIN";
            warehouse.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Warehouses.Add(warehouse);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        // GET: /Warehouse/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Warehouse warehouse = db.Warehouses.Find(splitid[0], splitid[1]);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: /Warehouse/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,WarehouseID,WarehouseName,PhoneNumber,WarehouseAddress,CreateUserID,CreateDateTime,ModifyUserID")] Warehouse warehouse)
        {
            warehouse.ModifyUserID = "ADMIN";
            warehouse.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(warehouse).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        // GET: /Warehouse/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Warehouse warehouse = db.Warehouses.Find(splitid[0], splitid[1]);

            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: /Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Warehouse warehouse = db.Warehouses.Find(splitid[0], splitid[1]);

            db.Warehouses.Remove(warehouse);
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
