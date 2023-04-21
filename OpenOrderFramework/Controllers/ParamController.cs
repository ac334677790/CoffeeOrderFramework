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
    public class ParamController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeYN()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "YN").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }


        //頁數
        private const int PageSize = 10;

        private IEnumerable<Param> ParamsList
        {
            get { return db.Params.OrderBy(x => x.ParaKind); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Params.OrderBy(x => x.ParaKind);

            int pageIndex = page < 1 ? 1 : page;

            var model = new ParamListViewModel
            {
                SearchParameter = new ParamSearchModel(),
                PageIndex = pageIndex,
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Params = query.ToPagedList(pageIndex, PageSize),
                CodeYN = GetAllCodeYN()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ParamListViewModel model)
        {
            var query = db.Params.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ParaKind))
            {
                query = query.Where(
                    x => x.ParaKind.Contains(model.SearchParameter.ParaKind));
            }



            query = query.OrderBy(x => x.ParaKind);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new ParamListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Params = query.ToPagedList(pageIndex, PageSize),
                CodeYN = GetAllCodeYN()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Param/
        //public ActionResult Index()
        //{
        //    return View(db.Params.ToList());
        //}

        // GET: /Param/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Param param = db.Params.Find(splitid[0], splitid[1], splitid[2]);
            if (param == null)
            {
                return HttpNotFound();
            }
            return View(param);
        }

        // GET: /Param/Create
        public ActionResult Create()
        {
            GetDropDownList();

            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var CodeYNs = this.GetAllCodeYN();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var CodeYN in CodeYNs)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeYN.Value,
                    Value = CodeYN.Key,
                    Selected = CodeYN.Key.Equals("Y")
                });
            }
            ViewBag.CodeYNs = items;
        }


        // POST: /Param/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,ParaKind,Para1,Para2,Para3,Para4,ParaName,Modify_YN,CreateUserID,ModifyUserID")] Param param)
        {
            param.CompanyID = "S1";
            param.CreateUserID = "ADMIN";
            param.CreateDateTime = DateTime.Now;
            param.ModifyUserID = "ADMIN";
            param.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Params.Add(param);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(param);
        }

        // GET: /Param/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Param param = db.Params.Find(splitid[0], splitid[1], splitid[2]);
            if (param == null)
            {
                return HttpNotFound();
            }
            return View(param);
        }

        // POST: /Param/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,ParaKind,Para1,Para2,Para3,Para4,ParaName,Modify_YN,CreateUserID,CreateDateTime,ModifyUserID")] Param param)
        {
            param.ModifyUserID = "ADMIN";
            param.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(param).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(param);
        }

        // GET: /Param/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Param param = db.Params.Find(splitid[0], splitid[1], splitid[2]);
            if (param == null)
            {
                return HttpNotFound();
            }
            return View(param);
        }

        // POST: /Param/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Param param = db.Params.Find(splitid[0], splitid[1], splitid[2]);
            db.Params.Remove(param);
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
