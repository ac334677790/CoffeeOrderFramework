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
    public class ProductController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
        private Dictionary<string, string> GetAllProductKind()
        {
            var query = db.ProductKinds.OrderBy(x => x.ProdKind);
            return query.ToDictionary(x => x.ProdKind.ToString(), x => x.ProdKindName);
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllFactory()
        {
            var query = db.Factorys.OrderBy(x => x.FactoryID);
            return query.ToDictionary(x => x.FactoryID.ToString(), x => x.ShortName);
        }

        //細項下拉字典
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeSize()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Size").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeTemperature()
        {
            var query = db.Codes.OrderBy(x => x.CodeID);
            return query.Where(x => x.Code_Kind == "Temperature").ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        
        //頁數
        private const int PageSize = 10;

        private IEnumerable<Product> ProductsList
        {
            get { return db.Products.OrderBy(x => x.ProductID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Products.OrderBy(x => x.ProductID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new ProductListViewModel
            {
                SearchParameter = new ProductSearchModel(),
                PageIndex = pageIndex,
                ProductIDs = new SelectList(this.ProductsList, "ProductID", "ProdName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Products = query.ToPagedList(pageIndex, PageSize),
                ProductKind = GetAllProductKind(),
                Factory = GetAllFactory(),
                CodeTemperature = GetAllCodeTemperature(),
                CodeSize = GetAllCodeSize()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProductListViewModel model)
        {
            var query = db.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProdName))
            {
                query = query.Where(
                    x => x.ProdName.Contains(model.SearchParameter.ProdName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProdSpec))
            {
                query = query.Where(
                    x => x.ProdSpec.Contains(model.SearchParameter.ProdSpec));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProductID))
            {
                query = query.Where(x => x.ProductID.Contains(model.SearchParameter.ProductID));

            }

            query = query.OrderBy(x => x.ProductID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new ProductListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                ProductIDs = new SelectList(
                    items: this.ProductsList, dataValueField: "ProductID",
                    dataTextField: "ProdName",
                    selectedValue: model.SearchParameter.ProductID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Products = query.ToPagedList(pageIndex, PageSize),
                ProductKind = GetAllProductKind(),
                Factory = GetAllFactory(),
                CodeTemperature = GetAllCodeTemperature(),
                CodeSize = GetAllCodeSize()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Product/
        //public ActionResult Index()
        //{
        //    return View(db.Products.ToList());
        //}

        // GET: /Product/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Product product = db.Products.Find(splitid[0], splitid[1]);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            //自動編號
            string productID = "SP" + (db.Products.Where(x => x.ProductID.StartsWith("SP")).Count() + 1).ToString();
            ViewBag.productID = productID;
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

            //下拉帶入ViewBag
            var factories = this.GetAllFactory();

            items = new List<SelectListItem>();
            foreach (var factory in factories)
            {
                items.Add(new SelectListItem()
                {
                    Text = factory.Value,
                    Value = factory.Key
                });
            }
            ViewBag.Factories = items;
        }

        // POST: /Product/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,ProductID,ProdKind,BarCode,ProdName,ProdSpec,ProdColor,ProdUnit,UnitWeight,ProdPhoto,New_YN,ProdOrigin,ProdSubject,FactoryID,FinalPrice,AvegPrice,CostPrice,SalePrice,WarehouseID,BarCode_YN,CheckStock_YN,StockIO_YN,SafeQty,DataStatus,Temperature,Sugar,Size,Memo,CreateUserID,ModifyUserID")] Product product)
        {
            product.CompanyID = "S1";
            product.CreateUserID = "ADMIN";
            product.CreateDateTime = DateTime.Now;
            product.ModifyUserID = "ADMIN";
            product.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Product product = db.Products.Find(splitid[0], splitid[1]);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,ProductID,ProdKind,BarCode,ProdName,ProdSpec,ProdColor,ProdUnit,UnitWeight,ProdPhoto,New_YN,ProdOrigin,ProdSubject,FactoryID,FinalPrice,AvegPrice,CostPrice,SalePrice,WarehouseID,BarCode_YN,CheckStock_YN,StockIO_YN,SafeQty,DataStatus,Temperature,Sugar,Size,Memo,CreateUserID,CreateDateTime,ModifyUserID")] Product product)
        {
            product.ModifyUserID = "ADMIN";
            product.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Product product = db.Products.Find(splitid[0], splitid[1]);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Product product = db.Products.Find(splitid[0], splitid[1]);
            db.Products.Remove(product);

            //細項也要刪除
            string companyID = splitid[0];
            string productID = splitid[1];
            db.Product_ds.RemoveRange(db.Product_ds.Where(x => x.CompanyID == companyID && x.ProductID == productID));

            db.SaveChanges();
            TempData["save"] = "save";
            return RedirectToAction("Index");
        }

        // GET: /Order_m/SelectProduct/
        public ActionResult SelectProduct(string id)
        {
            var query = db.Products.OrderBy(x => x.ProductID);


            var result = new SelectProductViewModel
            {
                Products = query.ToPagedList(1, 99)
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');


            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
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
