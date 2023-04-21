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
    public class ProductKindController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
        private Dictionary<string, string> GetAllProductKind()
        {
            var query = db.ProductKinds.OrderBy(x => x.ProdKind);
            return query.ToDictionary(x => x.ProdKind.ToString(), x => x.ProdKindName);
        }

        //頁數
        private const int PageSize = 10;

        private IEnumerable<ProductKind> ProductKindsList
        {
            get { return db.ProductKinds.OrderBy(x => x.ProdKind); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.ProductKinds.OrderBy(x => x.ProdKind);

            int pageIndex = page < 1 ? 1 : page;

            var model = new ProductKindListViewModel
            {
                SearchParameter = new ProductKindSearchModel(),
                PageIndex = pageIndex,
                ProdKinds = new SelectList(this.ProductKindsList, "ProdKind", "ProdKindName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                ProductKinds = query.ToPagedList(pageIndex, PageSize)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProductKindListViewModel model)
        {
            var query = db.ProductKinds.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProdKind))
            {
                query = query.Where(
                    x => x.ProdKind.Contains(model.SearchParameter.ProdKind));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProdKindName))
            {
                query = query.Where(
                    x => x.ProdKindName.Contains(model.SearchParameter.ProdKindName));
            }



            query = query.OrderBy(x => x.ProdKind);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new ProductKindListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                ProdKinds = new SelectList(
                    items: this.ProductKindsList, dataValueField: "ProdKind",
                    dataTextField: "ProdKindName",
                    selectedValue: model.SearchParameter.ProdKind),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                ProductKinds = query.ToPagedList(pageIndex, PageSize)
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /ProductKind/
        //public ActionResult Index()
        //{
        //    return View(db.ProductKinds.ToList());
        //}

        // GET: /ProductKind/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            ProductKind productkind = db.ProductKinds.Find(splitid[0], splitid[1]);
            if (productkind == null)
            {
                return HttpNotFound();
            }
            return View(productkind);
        }

        // GET: /ProductKind/Create
        public ActionResult Create()
        {
            GetDropDownList();

            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var productKinds = this.GetAllProductKind();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var productKind in productKinds)
            {
                items.Add(new SelectListItem()
                {
                    Text = productKind.Value,
                    Value = productKind.Key
                });
            }
            ViewBag.ProdKinds = items;
        }

        // POST: /ProductKind/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,ProdKind,ProdKindName,ParentProdKind,Code1,Code2,Photo,Memo,CreateUserID,CreateDateTime,ModifyUserID")] ProductKind productkind)
        {
            productkind.CompanyID = "S1";
            productkind.CreateUserID = "ADMIN";
            productkind.CreateDateTime = DateTime.Now;
            productkind.ModifyUserID = "ADMIN";
            productkind.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.ProductKinds.Add(productkind);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(productkind);
        }

        // GET: /ProductKind/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            ProductKind productkind = db.ProductKinds.Find(splitid[0], splitid[1]);
            if (productkind == null)
            {
                return HttpNotFound();
            }
            return View(productkind);
        }

        // POST: /ProductKind/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompanyID,ProdKind,ProdKindName,ParentProdKind,Code1,Code2,Photo,Memo")] ProductKind productkind)
        {
            productkind.ModifyUserID = "ADMIN";
            productkind.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(productkind).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(productkind);
        }

        // GET: /ProductKind/Delete/5
        public ActionResult Delete(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            ProductKind productkind = db.ProductKinds.Find(splitid[0], splitid[1]);
            if (productkind == null)
            {
                return HttpNotFound();
            }
            return View(productkind);
        }

        // POST: /ProductKind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            ProductKind productkind = db.ProductKinds.Find(splitid[0], splitid[1]);
            db.ProductKinds.Remove(productkind);
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
