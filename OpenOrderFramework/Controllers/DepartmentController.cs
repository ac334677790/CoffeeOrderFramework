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
    public class DepartmentController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Department> DepartmentsList
        {
            get { return db.Departments.OrderBy(x => x.DeptID); }
        }


        //定義下拉字典
        private Dictionary<string, string> GetAllDepartment()
        {
            var query = db.Departments.OrderBy(x => x.DeptID);
            return query.ToDictionary(x => x.DeptID.ToString(), x => x.DeptName);
        }        

        //定義下拉字典
        private Dictionary<string, string> GetAllEmployees()
        {
            var query = db.Employees.OrderBy(x => x.EmpID);
            return query.ToDictionary(x => x.EmpID.ToString(), x => x.EmpName);
        }


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Departments.OrderBy(x => x.DeptID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new DepartmentListViewModel
            {
                SearchParameter = new DepartmentSearchModel(),
                PageIndex = pageIndex,
                DeptIDs = new SelectList(this.DepartmentsList, "DeptID", "DeptName"),
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Departments = query.ToPagedList(pageIndex, PageSize),
                Department=GetAllDepartment(),
                Employees = GetAllEmployees()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DepartmentListViewModel model)
        {            
            var query = db.Departments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.DeptID))
            {
                query = query.Where(
                    x => x.DeptID.Contains(model.SearchParameter.DeptID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.DeptName))
            {
                query = query.Where(
                    x => x.DeptName.Contains(model.SearchParameter.DeptName));
            }


            query = query.OrderBy(x => x.DeptID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new DepartmentListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                DeptIDs = new SelectList(
                    items: this.DepartmentsList, dataValueField: "DeptID",
                    dataTextField: "DeptName",
                    selectedValue: model.SearchParameter.DeptID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Departments = query.ToPagedList(pageIndex, PageSize),
                Department = GetAllDepartment(),
                Employees = GetAllEmployees()
            };

            return View(result);

        }


        //// GET: /Department/
        //public ActionResult Index()
        //{
        //    return View(db.Departments.ToList());
        //}

        // GET: /Department/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Department department = db.Departments.Find(splitid[0], splitid[1]);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: /Department/Create
        public ActionResult Create()
        {
            GetDropDownList();

            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var Departments = this.GetAllDepartment();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Department in Departments)
            {
                items.Add(new SelectListItem()
                {
                    Text = Department.Value,
                    Value = Department.Key
                });
            }
            ViewBag.Departments = items;

            //下拉帶入ViewBag
            var Employeeses = this.GetAllEmployees();

            items = new List<SelectListItem>();
            foreach (var Employees in Employeeses)
            {
                items.Add(new SelectListItem()
                {
                    Text = Employees.Value,
                    Value = Employees.Key
                });
            }
            ViewBag.Employeeseses = items;

        }


        // POST: /Department/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompanyID,DeptID,DeptName,ParentDeptID,DeptDirectorID,ValidDate,InValidDate,CreateUserID,ModifyUserID")] Department department)
        {
            department.CompanyID = "S1";
            department.CreateUserID = "ADMIN";
            department.CreateDateTime = DateTime.Now;
            department.ModifyUserID = "ADMIN";
            department.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: /Department/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Department department = db.Departments.Find(splitid[0], splitid[1]);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: /Department/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompanyID,DeptID,DeptName,ParentDeptID,DeptDirectorID,ValidDate,InValidDate,CreateUserID,CreateDateTime,ModifyUserID")] Department department)
        {
            department.ModifyUserID = "ADMIN";
            department.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: /Department/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Department department = db.Departments.Find(splitid[0], splitid[1]);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Department department = db.Departments.Find(splitid[0], splitid[1]);
            db.Departments.Remove(department);
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
