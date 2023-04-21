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
    public class CombProduct_mController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<CombProduct_m> CombCombProduct_m_msList
        {
            get { return db.CombProduct_ms.OrderBy(x => x.CombProductID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.CombProduct_ms.OrderBy(x => x.CombProductID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new CombProduct_mListViewModel
            {
                SearchParameter = new CombProduct_mSearchModel(),
                PageIndex = pageIndex,
                CombProductIDs = new SelectList(this.CombCombProduct_m_msList, "CombProductID", "CombProductName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                CombProduct_ms = query.ToPagedList(pageIndex, PageSize),
                CombProduct_ds = db.CombProduct_ds.OrderBy(x => x.CombProdSeq).ToPagedList(1, 9999)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CombProduct_mListViewModel model)
        {
            var query = db.CombProduct_ms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CombProdName))
            {
                query = query.Where(
                    x => x.CombProdName.Contains(model.SearchParameter.CombProdName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CombProdSpec))
            {
                query = query.Where(
                    x => x.CombProdSpec.Contains(model.SearchParameter.CombProdSpec));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CombProductID))
            {
                query = query.Where(x => x.CombProductID.Contains(model.SearchParameter.CombProductID));

            }

            query = query.OrderBy(x => x.CombProductID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new CombProduct_mListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                CombProductIDs = new SelectList(
                    items: this.CombCombProduct_m_msList, dataValueField: "CombProductID",
                    dataTextField: "ProdName",
                    selectedValue: model.SearchParameter.CombProductID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                CombProduct_ms = query.ToPagedList(pageIndex, PageSize),
                CombProduct_ds = db.CombProduct_ds.OrderBy(x => x.CombProdSeq).ToPagedList(1, 9999)
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /CombProduct_m/
        //public ActionResult Index()
        //{
        //    return View(db.CombProduct_ms.ToList());
        //}

        // GET: /CombProduct_m/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CombProduct_m combproduct_m = db.CombProduct_ms.Find(splitid[0], splitid[1]);
            if (combproduct_m == null)
            {
                return HttpNotFound();
            }
            return View(combproduct_m);
        }

        // GET: /CombProduct_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CombProduct_m/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,CombProductID,CombProdName,CombProdSpec,Photo,Memo,CreateUserID,ModifyUserID")] CombProduct_m combproduct_m)
        {
            combproduct_m.CompanyID = "S1";
            combproduct_m.CreateUserID = "ADMIN";
            combproduct_m.CreateDateTime = DateTime.Now;
            combproduct_m.ModifyUserID = "ADMIN";
            combproduct_m.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.CombProduct_ms.Add(combproduct_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(combproduct_m);
        }

        // GET: /CombProduct_m/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CombProduct_m combproduct_m = db.CombProduct_ms.Find(splitid[0], splitid[1]); 
            if (combproduct_m == null)
            {
                return HttpNotFound();
            }
            return View(combproduct_m);
        }

        // POST: /CombProduct_m/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,CombProductID,CombProdName,CombProdSpec,Photo,Memo,CreateUserID,CreateDateTime,ModifyUserID")] CombProduct_m combproduct_m)
        {
            combproduct_m.ModifyUserID = "ADMIN";
            combproduct_m.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(combproduct_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(combproduct_m);
        }

        // GET: /CombProduct_m/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CombProduct_m combproduct_m = db.CombProduct_ms.Find(splitid[0], splitid[1]); 
            if (combproduct_m == null)
            {
                return HttpNotFound();
            }
            return View(combproduct_m);
        }

        // POST: /CombProduct_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            CombProduct_m combproduct_m = db.CombProduct_ms.Find(splitid[0], splitid[1]);
            db.CombProduct_ms.Remove(combproduct_m);


            //細項也要刪除
            string companyID = splitid[0];
            string combProductID = splitid[1];
            db.CombProduct_ds.RemoveRange(db.CombProduct_ds.Where(x => x.CompanyID == companyID && x.CombProductID == combProductID));

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
    }
}
