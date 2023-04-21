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
    public class FactoryController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeFactoryLevel()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "FactoryLevel").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeFactoryType()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "FactoryType").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Factory> FactorysList
        {
            get { return db.Factorys.OrderBy(x => x.FactoryID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Factorys.OrderBy(x => x.FactoryID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new FactoryListViewModel
            {
                SearchParameter = new FactorySearchModel(),
                PageIndex = pageIndex,
                FactoryIDs = new SelectList(this.FactorysList, "FactoryID", "FactoryName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Factorys = query.ToPagedList(pageIndex, PageSize),
                CodeFactoryLevel= GetAllCodeFactoryLevel(),
                CodeFactoryType = GetAllCodeFactoryType()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FactoryListViewModel model)
        {
            var query = db.Factorys.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.FactoryID))
            {
                query = query.Where(
                    x => x.FactoryID.Contains(model.SearchParameter.FactoryID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.FactoryName))
            {
                query = query.Where(
                    x => x.FactoryName.Contains(model.SearchParameter.FactoryName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.FactoryName))
            {
                query = query.Where(
                    x => x.ShortName.Contains(model.SearchParameter.FactoryName));
            }

            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.FactoryID))
            {
                query = query.Where(x => x.FactoryID.Contains(model.SearchParameter.FactoryID));

            }

            query = query.OrderBy(x => x.FactoryID);
            
            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new FactoryListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                FactoryIDs = new SelectList(
                    items: this.FactorysList, dataValueField: "FactoryID",
                    dataTextField: "FactoryName",
                    selectedValue: model.SearchParameter.FactoryID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Factorys = query.ToPagedList(pageIndex, PageSize),
                CodeFactoryLevel = GetAllCodeFactoryLevel(),
                CodeFactoryType = GetAllCodeFactoryType()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Factory/
        //public ActionResult Index()
        //{
        //    return View(db.Factorys.ToList());
        //}

        // GET: /Factory/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Factory Factory = db.Factorys.Find(splitid[0], splitid[1]);
            if (Factory == null)
            {
                return HttpNotFound();
            }
            return View(Factory);
        }

        // GET: /Factory/Create
        public ActionResult Create()
        {
            GetDropDownList();

            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var CodeFactoryLevels = this.GetAllCodeFactoryLevel();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var CodeFactoryLevel in CodeFactoryLevels)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeFactoryLevel.Value,
                    Value = CodeFactoryLevel.Key
                });
            }
            ViewBag.CodeFactoryLevels = items;

            //下拉帶入ViewBag
            var CodeFactoryTypes = this.GetAllCodeFactoryType();

            items = new List<SelectListItem>();
            foreach (var CodeFactoryType in CodeFactoryTypes)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeFactoryType.Value,
                    Value = CodeFactoryType.Key
                });
            }
            ViewBag.CodeFactoryTypes = items;
        }


        // POST: /Factory/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,FactoryID,ShortName,FactoryName,PostalCode,c_PostalCode,CompanyAddress,ChargeName,PhoneCountryCode,PhoneAreaCode,PhoneNumber,FaxNumber,Email,ContactName,ContactTiitle,TelephoneNumber,MobileNumber,Email,CloseDate,PayDate,PayDays,TaxID,Site,FactoryLevel,FactoryType,Bank1,Account1,Bank2,Account2,PayTerms,PayCode,Memo,Acct_no_ar1,Acct_no_ar2,Acct_no_ar3,Acct_no_ar4,Acct_no_ar5,Acct_no_ar6,InValidDate,CreateUserID,ModifyUserID")] Factory Factory)
        {
            Factory.CompanyID = "S1";
            Factory.CreateUserID = "ADMIN";
            Factory.CreateDateTime = DateTime.Now;
            Factory.ModifyUserID = "ADMIN";
            Factory.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Factorys.Add(Factory);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(Factory);
        }

        // GET: /Factory/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Factory Factory = db.Factorys.Find(splitid[0], splitid[1]);
            if (Factory == null)
            {
                return HttpNotFound();
            }
            return View(Factory);
        }

        // POST: /Factory/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,FactoryID,ShortName,FactoryName,PostalCode,c_PostalCode,CompanyAddress,ChargeName,PhoneCountryCode,PhoneAreaCode,PhoneNumber,FaxNumber,Email,ContactName,ContactTiitle,TelephoneNumber,MobileNumber,Email,CloseDate,PayDate,PayDays,TaxID,Site,FactoryLevel,FactoryType,Bank1,Account1,Bank2,Account2,PayTerms,PayCode,Memo,Acct_no_ar1,Acct_no_ar2,Acct_no_ar3,Acct_no_ar4,Acct_no_ar5,Acct_no_ar6,InValidDate,CreateUserID,CreateDateTime,ModifyUserID")] Factory Factory)
        {
            Factory.ModifyUserID = "ADMIN";
            Factory.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(Factory).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(Factory);
        }

        // GET: /Factory/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Factory Factory = db.Factorys.Find(splitid[0], splitid[1]);
            if (Factory == null)
            {
                return HttpNotFound();
            }
            return View(Factory);
        }

        // POST: /Factory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Factory Factory = db.Factorys.Find(splitid[0], splitid[1]);
            db.Factorys.Remove(Factory);
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
