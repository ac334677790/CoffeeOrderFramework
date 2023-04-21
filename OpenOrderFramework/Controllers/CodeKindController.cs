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
    public class CodeKindController : BaseController
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

        private IEnumerable<CodeKind> CodeKindsList
        {
            get { return db.CodeKinds.OrderBy(x => x.Code_Kind); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.CodeKinds.OrderBy(x => x.Code_Kind);
            
            int pageIndex = page < 1 ? 1 : page;

            var model = new CodeKindListViewModel
            {
                SearchParameter = new CodeKindSearchModel(),
                PageIndex = pageIndex,
                Code_Kinds = new SelectList(this.CodeKindsList, "Code_Kind", "Code_KindName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                CodeKinds = query.ToPagedList(pageIndex, PageSize),
                Codes = db.Codes.AsQueryable().OrderBy(x => x.CodeID).ToPagedList(pageIndex, 9999),
                CodeYN = GetAllCodeYN()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CodeKindListViewModel model)
        {
            var query = db.CodeKinds.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.Code_Kind))
            {
                query = query.Where(
                    x => x.Code_Kind.Contains(model.SearchParameter.Code_Kind));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.Code_KindName))
            {
                query = query.Where(
                    x => x.Code_KindName.Contains(model.SearchParameter.Code_KindName));
            }

            query = query.OrderBy(x => x.Code_Kind);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new CodeKindListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                Code_Kinds = new SelectList(
                    items: this.CodeKindsList, dataValueField: "Code_Kind",
                    dataTextField: "Code_KindName",
                    selectedValue: model.SearchParameter.Code_Kind),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                CodeKinds = query.ToPagedList(pageIndex, PageSize),
                Codes= db.Codes.AsQueryable().OrderBy(x => x.CodeID).ToPagedList(1,9999),
                CodeYN = GetAllCodeYN()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /CodeKind/
        //public ActionResult Index()
        //{
        //    return View(db.CodeKinds.ToList());
        //}

        // GET: /CodeKind/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CodeKind Codekind = db.CodeKinds.Find(splitid[0], splitid[1]);
            if (Codekind == null)
            {
                return HttpNotFound();
            }
            return View(Codekind);
        }

        // GET: /CodeKind/Create
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

        // POST: /CodeKind/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,Code_Kind,Code_KindName,Memo,Modify_YN,CreateUserID,ModifyUserID")] CodeKind Codekind)
        {
            Codekind.CompanyID = "S1";
            Codekind.CreateUserID = "ADMIN";
            Codekind.CreateDateTime = DateTime.Now;
            Codekind.ModifyUserID = "ADMIN";
            Codekind.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.CodeKinds.Add(Codekind);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(Codekind);
        }

        // GET: /CodeKind/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CodeKind Codekind = db.CodeKinds.Find(splitid[0], splitid[1]);
            if (Codekind == null)
            {
                return HttpNotFound();
            }
            return View(Codekind);
        }

        // POST: /CodeKind/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,Code_Kind,Code_KindName,Memo,Modify_YN,CreateUserID,CreateDateTime,ModifyUserID")] CodeKind Codekind)
        {
            Codekind.ModifyUserID = "ADMIN";
            Codekind.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(Codekind).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Codekind);
        }

        // GET: /CodeKind/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CodeKind Codekind = db.CodeKinds.Find(splitid[0], splitid[1]);
            if (Codekind == null)
            {
                return HttpNotFound();
            }
            return View(Codekind);
        }

        // POST: /CodeKind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            CodeKind Codekind = db.CodeKinds.Find(splitid[0], splitid[1]);            
            db.CodeKinds.Remove(Codekind);

            //細項也要刪除
            string companyID=splitid[0];
            string codeKind=splitid[1];
            db.Codes.RemoveRange(db.Codes.Where(x => x.CompanyID == companyID && x.Code_Kind == codeKind));

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
