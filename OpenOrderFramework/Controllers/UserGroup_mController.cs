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
    public class UserGroup_mController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<UserGroup_m> UserGroup_msList
        {
            get { return db.UserGroup_ms.OrderBy(x => x.GroupID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.UserGroup_ms.OrderBy(x => x.GroupID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new UserGroup_mListViewModel
            {
                SearchParameter = new UserGroup_mSearchModel(),
                PageIndex = pageIndex,
                GroupIDs = new SelectList(this.UserGroup_msList, "GroupID", "GroupDOC"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                UserGroup_ms = query.ToPagedList(pageIndex, PageSize),
                UserGroup_ds = db.UserGroup_ds.OrderBy(x => x.UserID).ToPagedList(1, 9999)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserGroup_mListViewModel model)
        {
            var query = db.UserGroup_ms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.GroupID))
            {
                query = query.Where(
                    x => x.GroupID.Contains(model.SearchParameter.GroupID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.GroupDOC))
            {
                query = query.Where(
                    x => x.GroupDOC.Contains(model.SearchParameter.GroupDOC));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.GroupID))
            {
                query = query.Where(x => x.GroupID.Contains(model.SearchParameter.GroupID));

            }

            query = query.OrderBy(x => x.GroupID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new UserGroup_mListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                GroupIDs = new SelectList(
                    items: this.UserGroup_msList, dataValueField: "GroupID",
                    dataTextField: "GroupDOC",
                    selectedValue: model.SearchParameter.GroupID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                UserGroup_ms = query.ToPagedList(pageIndex, PageSize),
                UserGroup_ds =db.UserGroup_ds.OrderBy(x => x.UserID).ToPagedList(1, 9999)
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /UserGroup_m/
        //public ActionResult Index()
        //{
        //    return View(db.UserGroup_ms.ToList());
        //}

        // GET: /UserGroup_m/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            UserGroup_m usergroup_m = db.UserGroup_ms.Find(splitid[0], splitid[1]);
            if (usergroup_m == null)
            {
                return HttpNotFound();
            }
            return View(usergroup_m);
        }

        // GET: /UserGroup_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserGroup_m/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,GroupID,GroupDOC,Memo,CreateUserID,ModifyUserID")] UserGroup_m usergroup_m)
        {
            usergroup_m.CompanyID = "S1";
            usergroup_m.CreateUserID = "ADMIN";
            usergroup_m.CreateDateTime = DateTime.Now;
            usergroup_m.ModifyUserID = "ADMIN";
            usergroup_m.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.UserGroup_ms.Add(usergroup_m);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(usergroup_m);
        }

        // GET: /UserGroup_m/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            UserGroup_m usergroup_m = db.UserGroup_ms.Find(splitid[0], splitid[1]);
            if (usergroup_m == null)
            {
                return HttpNotFound();
            }
            return View(usergroup_m);
        }

        // POST: /UserGroup_m/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,GroupID,GroupDOC,Memo,CreateUserID,CreateDateTime,ModifyUserID")] UserGroup_m usergroup_m)
        {
            usergroup_m.ModifyUserID = "ADMIN";
            usergroup_m.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(usergroup_m).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(usergroup_m);
        }

        // GET: /UserGroup_m/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            UserGroup_m usergroup_m = db.UserGroup_ms.Find(splitid[0], splitid[1]);
            if (usergroup_m == null)
            {
                return HttpNotFound();
            }
            return View(usergroup_m);
        }

        // POST: /UserGroup_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            UserGroup_m usergroup_m = db.UserGroup_ms.Find(splitid[0], splitid[1]);
            db.UserGroup_ms.Remove(usergroup_m);

            //細項也要刪除
            string companyID = splitid[0];
            string groupID = splitid[1];
            TempData["save"] = "save";
            db.UserGroup_ds.RemoveRange(db.UserGroup_ds.Where(x => x.CompanyID == companyID && x.GroupID == groupID));

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
