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
    public class CustomerController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Customer> CustLevelList
        {
            get { return db.Customers.OrderBy(x => x.CustomerID); }
        }

        private IEnumerable<Customer> CustTypelList
        {
            get { return db.Customers.OrderBy(x => x.CustomerID); }
        }

        private IEnumerable<Customer> SexTypelList
        {
            get { return db.Customers.OrderBy(x => x.CustomerID); }
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeSex()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "Sex").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeYN()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "YN").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeCustLevel()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "CustLevel").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeCustType()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "CustType").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }
        //定義下拉字典
        private Dictionary<string, string> GetAllCodeOccupation()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "Occupation").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllDepartment()
        {
            var query = db.Departments.OrderBy(x => x.DeptID);
            return query.ToDictionary(x => x.DeptID.ToString(), x => x.DeptName);
        }


        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}




        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Customers.OrderBy(x => x.CustomerID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new CustomerListViewModel
            {
                SearchParameter = new CustomerSearchModel(),
                PageIndex = pageIndex,
                CustLevel = new SelectList(this.CustLevelList, "CodeID", "CodeName"),
                CustType = new SelectList(this.CustTypelList, "CodeID", "CodeName"),
                SexType = new SelectList(this.SexTypelList, "CodeID", "CodeName"),

                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Customers = query.ToPagedList(pageIndex, PageSize),
                CodeCustLevel = GetAllCodeCustLevel(),
                CodeCustType = GetAllCodeCustType(),
                CodeOccupation = GetAllCodeOccupation(),
                CodeSex = GetAllCodeSex(),
                CodeYN = GetAllCodeYN()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CustomerListViewModel model)
        {
            var query = db.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustomerID))
            {
                query = query.Where(
                    x => x.CustomerID.Contains(model.SearchParameter.CustomerID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustName))
            {
                query = query.Where(
                    x => x.CustName.Contains(model.SearchParameter.CustName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustName))
            {
                query = query.Where(
                    x => x.ShortName.Contains(model.SearchParameter.CustName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustType))
            {
                query = query.Where(
                    x => x.CustType.Contains(model.SearchParameter.CustType));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustLevel))
            {
                query = query.Where(
                    x => x.CustLevel.Contains(model.SearchParameter.CustLevel));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.SexType))
            {
                query = query.Where(
                    x => x.SexType.Contains(model.SearchParameter.SexType));
            }

            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.CustomerID))
            {
                query = query.Where(x => x.CustomerID.Contains(model.SearchParameter.CustomerID));

            }

            query = query.OrderBy(x => x.CustomerID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new CustomerListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                CustLevel = new SelectList(
                    items: this.CustLevelList, dataValueField: "CodeID",
                    dataTextField: "CodeName",
                    selectedValue: model.SearchParameter.CustLevel),
                CustType = new SelectList(
                    items: this.CustTypelList, dataValueField: "CodeID",
                    dataTextField: "CodeName",
                    selectedValue: model.SearchParameter.CustLevel),
                SexType = new SelectList(
                    items: this.SexTypelList, dataValueField: "CodeID",
                    dataTextField: "CodeName",
                    selectedValue: model.SearchParameter.CustLevel),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Customers = query.ToPagedList(pageIndex, PageSize),
                CodeCustLevel = GetAllCodeCustLevel(),
                CodeCustType = GetAllCodeCustType(),
                CodeOccupation = GetAllCodeOccupation(),
                CodeSex = GetAllCodeSex(),
                CodeYN = GetAllCodeYN()

            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Customer/
        //public ActionResult Index()
        //{
        //    return View(db.Customeromers.ToList());
        //}

        // GET: /Customer/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Cust/Create
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
                    Selected = CodeYN.Key.Equals("N")
                });
            }
            ViewBag.CodeYNs = items;

            //下拉帶入ViewBag
            var CodeSexs = this.GetAllCodeSex();

            items = new List<SelectListItem>();
            foreach (var CodeSex in CodeSexs)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeSex.Value,
                    Value = CodeSex.Key,
                    Selected = CodeSex.Key.Equals("M")
                });
            }
            ViewBag.CodeSexs = items;

            //下拉帶入ViewBag
            var CodeCustLevels = this.GetAllCodeCustLevel();

            items = new List<SelectListItem>();
            foreach (var CodeCustLevel in CodeCustLevels)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeCustLevel.Value,
                    Value = CodeCustLevel.Key
                });
            }
            ViewBag.CodeCustLevels = items;

            //下拉帶入ViewBag
            var CodeCustTypes = this.GetAllCodeCustType();

            items = new List<SelectListItem>();
            foreach (var CodeCustType in CodeCustTypes)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeCustType.Value,
                    Value = CodeCustType.Key
                });
            }
            ViewBag.CodeCustTypes = items;

            //下拉帶入ViewBag
            var CodeOccupations = this.GetAllCodeOccupation();

            items = new List<SelectListItem>();
            foreach (var CodeOccupation in CodeOccupations)
            {
                items.Add(new SelectListItem()
                {
                    Text = CodeOccupation.Value,
                    Value = CodeOccupation.Key
                });
            }
            ViewBag.CodeOccupations = items;

            //下拉帶入ViewBag
            var Departments = this.GetAllDepartment();

            items = new List<SelectListItem>();
            foreach (var Department in Departments)
            {
                items.Add(new SelectListItem()
                {
                    Text = Department.Value,
                    Value = Department.Key
                });
            }
            ViewBag.Departments = items;
        }

        // POST: /Cust/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustName,CustPassword,ShortName,SexType,CustLevel,CustType,ContactName,TelephoneNumber,MobileNumber,Email,EmailValidated,TaxID,PostalCode,Address,PostalCode2,Address2,Memo,ValidDate,InValidDate,StoredPoint,Birthday,Job,CreateUserID,ModifyUserID")] Customer customer)
        {
            customer.CreateUserID = "ADMIN";
            customer.CreateDateTime = DateTime.Now;
            customer.ModifyUserID = "ADMIN";
            customer.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: /Cust/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Cust/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustName,CustPassword,ShortName,SexType,CustLevel,CustType,ContactName,TelephoneNumber,MobileNumber,Email,EmailValidated,TaxID,PostalCode,Address,PostalCode2,Address2,Memo,ValidDate,InValidDate,StoredPoint,Birthday,Job,CreateUserID,CreateDateTime,ModifyUserID")] Customer customer)
        {
            customer.ModifyUserID = "ADMIN";
            customer.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: /Cust/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Customer customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Cust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
