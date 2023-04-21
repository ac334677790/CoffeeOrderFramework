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
    public class PositionController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Position> PositionsList
        {
            get { return db.Positions.OrderBy(x => x.PositionID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Positions.OrderBy(x => x.PositionID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new PositionListViewModel
            {
                SearchParameter = new PositionSearchModel(),
                PageIndex = pageIndex,
                PositionIDs = new SelectList(this.PositionsList, "PositionID", "PositionName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Positions = query.ToPagedList(pageIndex, PageSize)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PositionListViewModel model)
        {
            var query = db.Positions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.PositionID))
            {
                query = query.Where(
                    x => x.PositionID.Contains(model.SearchParameter.PositionID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.PositionLevel))
            {
                query = query.Where(
                    x => x.PositionLevel.Contains(model.SearchParameter.PositionLevel));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.PositionName))
            {
                query = query.Where(
                    x => x.PositionName.Contains(model.SearchParameter.PositionName));
            }


            query = query.OrderBy(x => x.PositionID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new PositionListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                PositionIDs = new SelectList(
                    items: this.PositionsList, dataValueField: "PositionID",
                    dataTextField: "PositionName",
                    selectedValue: model.SearchParameter.PositionID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Positions = query.ToPagedList(pageIndex, PageSize)
            };

            return View(result);

        }


        //// GET: /Position/
        //public ActionResult Index()
        //{
        //    return View(db.Positions.ToList());
        //}

        // GET: /Position/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Position position = db.Positions.Find(splitid[0], splitid[1]);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: /Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Position/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompanyID,PositionID,PositionName,PositionLevel,CreateUserID,ModifyUserID")] Position position)
        {
            position.CompanyID = "S1";
            position.CreateUserID = "ADMIN";
            position.CreateDateTime = DateTime.Now;
            position.ModifyUserID = "ADMIN";
            position.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: /Position/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');            
            Position position = db.Positions.Find(splitid[0], splitid[1]);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: /Position/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompanyID,PositionID,PositionName,PositionLevel,CreateUserID,CreateDateTime,ModifyUserID")] Position position)
        {
            position.ModifyUserID = "ADMIN";
            position.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: /Position/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Position position = db.Positions.Find(splitid[0], splitid[1]);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: /Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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
