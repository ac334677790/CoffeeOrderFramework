using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenOrderFramework.Models;
using PagedList;
using OpenOrderFramework.ViewModels;

namespace OpenOrderFramework.Controllers
{
    public class CompanyController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Company> CompanysList
        {
            get { return db.Companys.OrderBy(x => x.CompanyID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Companys.OrderBy(x => x.CompanyID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new CompanyListViewModel
            {
                SearchParameter = new CompanySearchModel(),
                PageIndex = pageIndex,
                CompanyIDs = new SelectList(this.CompanysList, "CompanyID", "CompanyName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Companys = query.ToPagedList(pageIndex, PageSize)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CompanyListViewModel model)
        {
            var query = db.Companys.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CompanyName))
            {
                query = query.Where(
                    x => x.CompanyName.Contains(model.SearchParameter.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CompanyName))
            {
                query = query.Where(
                    x => x.ShortName.Contains(model.SearchParameter.CompanyName));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CompanyID))
            {
                query = query.Where(x => x.CompanyID.Contains(model.SearchParameter.CompanyID));

            }

            query = query.OrderBy(x => x.CompanyID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new CompanyListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                CompanyIDs = new SelectList(
                    items: this.CompanysList, dataValueField: "CompanyID",
                    dataTextField: "CompanyName",
                    selectedValue: model.SearchParameter.CompanyID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Companys = query.ToPagedList(pageIndex, PageSize)
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Company/
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Companys.ToListAsync());
        //}

        // GET: /Company/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.Companys.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Company/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompanyID,CompanyName,ShortName,Area,PhoneCountryCode,PhoneAreaCode,PhoneNumber,FaxNumber,CompanyAddress,Site,Email,BusinessHourS,BusinessHourE,CreateUserID,ModifyUserID")] Company company)
        {
            company.CreateUserID = "ADMIN";
            company.CreateDateTime = DateTime.Now;
            company.ModifyUserID = "ADMIN";
            company.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Companys.Add(company);
                await db.SaveChangesAsync();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: /Company/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.Companys.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: /Company/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompanyID,CompanyName,ShortName,Area,PhoneCountryCode,PhoneAreaCode,PhoneNumber,FaxNumber,CompanyAddress,Site,Email,BusinessHourS,BusinessHourE,CreateUserID,CreateDateTime,ModifyUserID")] Company company)
        {
            company.ModifyUserID = "ADMIN";
            company.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: /Company/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.Companys.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: /Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Company company = await db.Companys.FindAsync(id);
            db.Companys.Remove(company);
            await db.SaveChangesAsync();
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
