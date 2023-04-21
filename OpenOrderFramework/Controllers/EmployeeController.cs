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
    public class EmployeeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        private IEnumerable<Employee> EmployeesList
        {
            get { return db.Employees.OrderBy(x => x.EmpID); }
        }

        private IEnumerable<Department> DepartmentsList
        {
            get { return db.Departments.OrderBy(x => x.DeptID); }
        }

        private IEnumerable<Position> PositionsesList
        {
            get { return db.Positions.OrderBy(x => x.PositionID); }
        }
        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}
        //定義下拉字典
        private Dictionary<string, string> GetAllDepartment()
        {
            var query = db.Departments.OrderBy(x => x.DeptID);
            return query.ToDictionary(x => x.DeptID.ToString(), x => x.DeptName);
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllPosition()
        {
            var query = db.Positions.OrderBy(x => x.PositionID);
            return query.ToDictionary(x => x.PositionID.ToString(), x => x.PositionName);
        }



        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Employees.OrderBy(x => x.EmpID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new EmployeeListViewModel
            {
                SearchParameter = new EmployeeSearchModel(),
                PageIndex = pageIndex,
                EmpIDs = new SelectList(this.EmployeesList, "EmpID", "ProdName"),
                DeptIDs = new SelectList(this.EmployeesList, "DeptID", "DeptName"),
                PositionIDs = new SelectList(this.EmployeesList, "PositionID", "PositionName"),
                Employees = query.ToPagedList(pageIndex, PageSize),
                Department = GetAllDepartment(),
                Position  = GetAllPosition()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EmployeeListViewModel model)
        {
            var query = db.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.EmpID))
            {
                query = query.Where(
                    x => x.EmpID.Contains(model.SearchParameter.EmpID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.EmpName))
            {
                query = query.Where(
                    x => x.EmpName.Contains(model.SearchParameter.EmpName));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.DeptID))
            {
                query = query.Where(
                    x => x.DeptID.Contains(model.SearchParameter.DeptID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.PositionID))
            {
                query = query.Where(
                    x => x.PositionID.Contains(model.SearchParameter.PositionID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.IDCard))
            {
                query = query.Where(
                    x => x.IDCard.Contains(model.SearchParameter.IDCard));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.EmpCardID))
            {
                query = query.Where(
                    x => x.EmpCardID.Contains(model.SearchParameter.EmpCardID));
            }

            query = query.OrderBy(x => x.EmpID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new EmployeeListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                EmpIDs = new SelectList(
                    items: this.EmployeesList, dataValueField: "EmpID",
                    dataTextField: "EmpName",
                    selectedValue: model.SearchParameter.EmpID),
                DeptIDs = new SelectList(
                    items: this.EmployeesList, dataValueField: "DeptID",
                    dataTextField: "DeptName",
                    selectedValue: model.SearchParameter.EmpID),
                PositionIDs = new SelectList(
                    items: this.EmployeesList, dataValueField: "PositionID",
                    dataTextField: "PositionName",
                    selectedValue: model.SearchParameter.EmpID),

                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Employees = query.ToPagedList(pageIndex, PageSize),
                Department = GetAllDepartment(),
                Position = GetAllPosition()
            };

            return View(result);

        }


        //// GET: /Employee/
        //public ActionResult Index()
        //{
        //    return View(db.Employees.ToList());
        //}

        // GET: /Employee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Employee employee = db.Employees.Find(splitid[0], splitid[1]);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
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
            var Positions = this.GetAllPosition();

            items = new List<SelectListItem>();
            foreach (var Position in Positions)
            {
                items.Add(new SelectListItem()
                {
                    Text = Position.Value,
                    Value = Position.Key,
                });
            }
            ViewBag.Positions = items;
        }

        // POST: /Employee/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompanyID,EmpID,EmpName,DeptID,PositionID,IDCard,PhoneNumber,Email,Memo,Birthday,EmpCardID,CreateUserID,ModifyUserID")] Employee employee)
        {
            employee.CompanyID = "S1";
            employee.CreateUserID = "ADMIN";
            employee.CreateDateTime = DateTime.Now;
            employee.ModifyUserID = "ADMIN";
            employee.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Employee employee = db.Employees.Find(splitid[0], splitid[1]);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompanyID,EmpID,EmpName,DeptID,PositionID,IDCard,PhoneNumber,Email,Memo,Birthday,EmpCardID,CreateUserID,CreateDateTime,ModifyUserID")] Employee employee)
        {
            employee.ModifyUserID = "ADMIN";
            employee.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Employee employee = db.Employees.Find(splitid[0], splitid[1]);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            TempData["save"] = "save";
            return RedirectToAction("Index");
        }


        // GET: /Order_m/SelectEmp/
        public ActionResult SelectEmp(string id)
        {
            var query = db.Employees.OrderBy(x => x.EmpID);


            var result = new SelectEmpViewModel
            {
                Employees = query.ToPagedList(1, 99)
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
