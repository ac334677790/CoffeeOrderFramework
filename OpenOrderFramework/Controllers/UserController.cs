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
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace OpenOrderFramework.Controllers
{
    public class UserController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //頁數
        private const int PageSize = 10;

        //定義下拉字典
        private Dictionary<string, string> GetAllEmployees()
        {
            var query = db.Employees.OrderBy(x => x.EmpID);
            return query.ToDictionary(x => x.EmpID.ToString(), x => x.EmpName);
        }


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = db.Users.OrderBy(x => x.UserID);

            int pageIndex = page < 1 ? 1 : page;

            var model = new UserListViewModel
            {
                SearchParameter = new UserSearchModel(),
                PageIndex = pageIndex,
                //Suppliers = new SelectList(this.Suppliers, "SupplierID", "CompanyName"),
                Users = query.ToPagedList(pageIndex, PageSize),
                Employees = GetAllEmployees()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserListViewModel model)
        {
            var query = db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.UserID))
            {
                query = query.Where(
                    x => x.UserID.Contains(model.SearchParameter.UserID));
            }

            query = query.OrderBy(x => x.UserID);

            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new UserListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                Users = query.ToPagedList(pageIndex, PageSize),
                Employees = GetAllEmployees()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /User/
        //public ActionResult Index()
        //{
        //    return View(db.Users.ToList());
        //}

        // GET: /User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            User user = db.Users.Find(splitid[0], splitid[1]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            GetDropDownList();



            return View();
        }

        private void GetDropDownList()
        {
            //下拉帶入ViewBag
            var Employeeses = this.GetAllEmployees();

            List<SelectListItem> items = new List<SelectListItem>();
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


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // POST: /User/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompanyID,UserID,UserPassword,EmpID,Email,Memo,InValidDate,CreateUserID,ModifyUserID")] User user)
        {
            //ModelState.Clear();
            user.CompanyID = "S1";
            user.CreateUserID = "ADMIN1";
            user.CreateDateTime = DateTime.Now;
            user.ModifyUserID = "ADMIN1";
            user.ModifyDateTime = DateTime.Now;

            if (user.Email == null)
            {
                user.Email = "asa@gamil.com";
            }
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                //寫入.NET角色
                var userAccount = new ApplicationUser { UserName = user.UserID + "@slive.com", Email = user.Email };
                var result = await UserManager.CreateAsync(userAccount, user.UserPassword);
                if (result.Succeeded)
                {
                    //寫入成功才寫入相關資料
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');            
            User user = db.Users.Find(splitid[0], splitid[1]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,UserID,UserPassword,EmpID,Email,Memo,InValidDate,CreateUserID,CreateDateTime,ModifyUserID")] User user)
        {
            user.ModifyUserID = "ADMIN";
            user.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                TempData["save"] = "save";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            User user = db.Users.Find(splitid[0], splitid[1]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            User user = db.Users.Find(splitid[0], splitid[1]);
            db.Users.Remove(user);
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
