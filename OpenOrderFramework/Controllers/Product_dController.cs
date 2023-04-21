using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;
using OpenOrderFramework.ViewModels;

namespace OpenOrderFramework.Controllers
{
    public class Product_dController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        // GET: /Product_d/
        public ActionResult Index(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string ProductID = splitid[1];
            ViewBag.CompanyID = CompanyID;
            ViewBag.ProductID = ProductID;

            var query = db.Product_ds.Where(x => x.ProductID == ProductID).OrderBy(x => x.Size);

            var model = new Product_dListViewModel
            {
                Product_ds = query.ToPagedList(1, 99),                
                CodeSize = GetAllCodeSize(),
                CodeTemperature = GetAllCodeTemperature()

            };

            return View(model);
        }

        // GET: /Product_d/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Product_d product_d = db.Product_ds.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            if (product_d == null)
            {
                return HttpNotFound();
            }
            return View(product_d);
        }

        // GET: /Product_d/Create
        public ActionResult Create(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string ProductID = splitid[1];
            ViewBag.CompanyID = CompanyID;
            ViewBag.ProductID = ProductID;

            GetDropDownList();

            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var CodeCodeSizes = this.GetAllCodeSize();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var CodeCodeSize in CodeCodeSizes)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeCodeSize.Value,
                    Value = CodeCodeSize.Key
                });
            }
            ViewBag.CodeSizes = items;


            //下拉帶入ViewBag
            var CodeTemperatures = this.GetAllCodeTemperature();

            items = new List<SelectListItem>();
            foreach (var CodeTemperature in CodeTemperatures)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeTemperature.Value,
                    Value = CodeTemperature.Key
                });
            }
            ViewBag.CodeTemperatures = items;
        }

        // POST: /Product_d/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompanyID,ProductID,Temperature,Size,SalePrice,Memo,CreateUserID,CreateDateTime,ModifyUserID,ModifyDateTime")] Product_d product_d)
        {
            product_d.CompanyID = "S1";
            product_d.CreateUserID = "ADMIN";
            product_d.CreateDateTime = DateTime.Now;
            product_d.ModifyUserID = "ADMIN";
            product_d.ModifyDateTime = DateTime.Now;



            if (ModelState.IsValid)
            {
                db.Product_ds.Add(product_d);
                db.SaveChanges();
                return RedirectToAction("../Proudct/Index");
            }

            return View(product_d);
        }

        // GET: /Product_d/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string ProductID = splitid[1];
            ViewBag.CompanyID = CompanyID;
            ViewBag.ProductID = ProductID;
            Product_d product_d = db.Product_ds.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            if (product_d == null)
            {
                return HttpNotFound();
            }
            return View(product_d);
        }

        // POST: /Product_d/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompanyID,ProductID,Temperature,Size,SalePrice,Memo,CreateUserID,CreateDateTime,ModifyUserID,ModifyDateTime")] Product_d product_d)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Proudct/Index");
            }
            return View(product_d);
        }

        // GET: /Product_d/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Product_d product_d = db.Product_ds.Find(splitid[0], splitid[1], splitid[2], splitid[3]);
            if (product_d == null)
            {
                return HttpNotFound();
            }
            return View(product_d);
        }

        // POST: /Product_d/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_d product_d = db.Product_ds.Find(id);
            db.Product_ds.Remove(product_d);
            db.SaveChanges();
            return RedirectToAction("../Proudct/Index");
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
