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
    public class LongOrder_mController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<LongOrder_m> LongOrder_msList
        {
            get { return db.LongOrder_ms.OrderBy(x => x.LongOrderNo); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeOrderDataStatus()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "OrderDataStatus").OrderBy(x => x.Code_Kind);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.LongOrder_ms.OrderBy(x => x.LongOrderNo);

            int pageIndex = page < 1 ? 1 : page;

            var model = new LongOrder_mListViewModel
            {
                SearchParameter = new LongOrder_mSearchModel(),
                PageIndex = pageIndex,
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                LongOrder_ms = query.ToPagedList(pageIndex, PageSize),
                CodeOrderDataStatus = GetAllCodeOrderDataStatus()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LongOrder_mListViewModel model)
        {
            var query = db.LongOrder_ms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.LongOrderNo))
            {
                query = query.Where(
                    x => x.LongOrderNo.Contains(model.SearchParameter.LongOrderNo));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.OrderNo))
            {
                query = query.Where(
                    x => x.OrderNo.Contains(model.SearchParameter.OrderNo));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.LongOrderNo))
            {
                query = query.Where(x => x.LongOrderNo.Contains(model.SearchParameter.LongOrderNo));

            }

            query = query.OrderBy(x => x.LongOrderNo);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new LongOrder_mListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                LongOrder_ms = query.ToPagedList(pageIndex, PageSize),
                CodeOrderDataStatus = GetAllCodeOrderDataStatus()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /LongOrder_m/
        //public ActionResult Index()
        //{
        //    return View(db.LongOrder_ms.ToList());
        //}

        // GET: /LongOrder_m/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            LongOrder_m longorder_m = db.LongOrder_ms.Find(splitid[0], splitid[1]);
            if (longorder_m == null)
            {
                return HttpNotFound();
            }
            return View(longorder_m);
        }

        // GET: /LongOrder_m/Create
        public ActionResult Create()
        {

            GetDropDownList();

            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var CodeOrderDataStatuses = this.GetAllCodeOrderDataStatus();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var CodeOrderDataStatus in CodeOrderDataStatuses)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeOrderDataStatus.Value,
                    Value = CodeOrderDataStatus.Key
                });
            }
            ViewBag.CodeOrderDataStatuses = items;
        }

        // POST: /LongOrder_m/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,LongOrderNo,OrderNo,DatetimeS,DatetimeE,CycleDay,CycleWeek,CycleMonth,CycleHour,Memo,DataStatus,CreateUserID,ModifyUserID")] LongOrder_m longorder_m)
        {
            longorder_m.CompanyID = "S1";
            longorder_m.CreateUserID = "ADMIN";
            longorder_m.CreateDateTime = DateTime.Now;
            longorder_m.ModifyUserID = "ADMIN";
            longorder_m.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.LongOrder_ms.Add(longorder_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(longorder_m);
        }

        // GET: /LongOrder_m/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            LongOrder_m longorder_m = db.LongOrder_ms.Find(splitid[0], splitid[1]); 
            if (longorder_m == null)
            {
                return HttpNotFound();
            }
            return View(longorder_m);
        }

        // POST: /LongOrder_m/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,LongOrderNo,OrderNo,DatetimeS,DatetimeE,CycleDay,CycleWeek,CycleMonth,CycleHour,Memo,DataStatus,CreateUserID,CreateDateTime,ModifyUserID")] LongOrder_m longorder_m)
        {
            longorder_m.ModifyUserID = "ADMIN";
            longorder_m.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(longorder_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(longorder_m);
        }

        // GET: /LongOrder_m/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            LongOrder_m longorder_m = db.LongOrder_ms.Find(splitid[0], splitid[1]); 
            if (longorder_m == null)
            {
                return HttpNotFound();
            }
            return View(longorder_m);
        }

        // POST: /LongOrder_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            LongOrder_m longorder_m = db.LongOrder_ms.Find(splitid[0], splitid[1]); 
            db.LongOrder_ms.Remove(longorder_m);
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
