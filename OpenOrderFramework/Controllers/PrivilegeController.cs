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
    public class PrivilegeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //定義下拉字典
        private Dictionary<string, string> GetAllUserGroupDOC()
        {
            var query = db.UserGroup_ms.OrderBy(x => x.GroupID);
            return query.ToDictionary(x => x.GroupID.ToString(), x => x.GroupDOC);
        }

        //頁數
        private const int PageSize = 10;

        private IEnumerable<UserGroup_m> UserGroupsList
        {
            get { return db.UserGroup_ms.OrderBy(x => x.GroupID); }
        }

        //private IEnumerable<Supplier> Suppliers
        //{
        //    get { return _db.Suppliers.OrderBy(x => x.CompanyName); }
        //}


        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var query = (from UG in db.UserGroup_ms
                                join PL in db.Privileges
                                on new { GroupID = UG.GroupID } equals new { GroupID = PL.GroupID } into ps
                         from PL in ps.DefaultIfEmpty()
                                orderby UG.GroupID 
                         select new PrivilegeUserGroupViewModel { GroupID = UG.GroupID, GroupDOC = UG.GroupDOC }).Distinct().ToList();

            int pageIndex = page < 1 ? 1 : page;

            var model = new PrivilegeListViewModel
            {
                SearchParameter = new PrivilegeSearchModel(),
                PageIndex = pageIndex,
                GroupIDs = new SelectList(this.UserGroupsList, "GroupID", "GroupDOC"),
                GroupID =query.Distinct().ToPagedList(pageIndex, PageSize),
                UserGroupDOC = GetAllUserGroupDOC()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PrivilegeListViewModel model)
        {
            var query = db.Privileges.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.GroupID))
            {
                query = query.Where(
                    x => x.GroupID.Contains(model.SearchParameter.GroupID));
            }
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.ProgramID))
            {
                query = query.Where(
                    x => x.ProgramID.Contains(model.SearchParameter.ProgramID));
            }


            //int categoryId;
            if (!string.IsNullOrWhiteSpace(model.SearchParameter.GroupID))
            {
                query = query.Where(x => x.GroupID.Contains(model.SearchParameter.GroupID));

            }

            //var query2 = query.OrderBy(x => x.GroupID).Select(x => x.GroupID).Distinct();

           var  query2 = (from UG in db.UserGroup_ms
                         join PL in db.Privileges
                         on new { GroupID = UG.GroupID } equals new { GroupID = PL.GroupID }
                         orderby UG.GroupID
                         select new PrivilegeUserGroupViewModel { GroupID = UG.GroupID, GroupDOC = UG.GroupDOC }).Distinct().ToList();


            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;

            var result = new PrivilegeListViewModel
            {
                SearchParameter = model.SearchParameter,
                PageIndex = model.PageIndex < 1 ? 1 : model.PageIndex,
                GroupIDs = new SelectList(
                    items: this.UserGroupsList, dataValueField: "GroupID",
                    dataTextField: "GroupDOC",
                    selectedValue: model.SearchParameter.GroupID),
                //Suppliers = new SelectList(
                //    items: this.Suppliers,
                //    dataValueField: "SupplierID",
                //    dataTextField: "CompanyName",
                //    selectedValue: model.SearchParameter.Supplier),
                GroupID = query2.ToPagedList(pageIndex, PageSize),
                UserGroupDOC = GetAllUserGroupDOC()
            };

            return View(result);

        }


        //[Authorize]
        //// GET: /Privilege/
        //public ActionResult Index()
        //{
        //    return View(db.Privileges.ToList());
        //}

        // GET: /Privilege/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Privilege privilege = db.Privileges.Find(splitid[0], splitid[1], splitid[2]);
            if (privilege == null)
            {
                return HttpNotFound();
            }
            return View(privilege);
        }

        // GET: /Privilege/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Privilege/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,GroupID,ProgramID,Add,Search,Modify,Delete,Print,Run,Help,Transform,CreateUserID,ModifyUserID")] Privilege privilege)
        {
            privilege.CompanyID = "S1";
            privilege.CreateUserID = "ADMIN";
            privilege.CreateDateTime = DateTime.Now;
            privilege.ModifyUserID = "ADMIN";
            privilege.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Privileges.Add(privilege);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privilege);
        }

        // GET: /Privilege/Edit/5
        public ActionResult Edit(string id)
        {
            var query = (from PL in db.Privileges.Where(x => x.GroupID == id)
                         join PG in db.Programs
                         on new {ProgramID = PL.ProgramID } equals new { ProgramID = PG.ProgramID } into ps
                         from PG in ps.DefaultIfEmpty()                         
                         join PPG in db.Programs.Where(x => x.ParentProgramID == "")
                        on PG.ParentProgramID equals PPG.ProgramID into pps
                         from PPG in pps.DefaultIfEmpty()  
                         orderby PPG.ProgramOrder
                         select new PrivilegeEditViewModel { 
                             privilege = PL,
                             ProgDescription  = PG.ProgDescription,
                             ProgramOrder = PG.ProgramOrder,
                             ParentProgramOrder = PPG.ProgramOrder,
                             ParentProgramID = PG.ParentProgramID,
                             IsModify = 0
                         }).Distinct().ToList();
            var result = new PrivilegeProgramViewModel
            {
                ProgramEdit = query.OrderBy(x => x.ParentProgramOrder).ThenBy(x => x.ProgramOrder).ToList()
            };
            //List<PrivilegeEditViewModel> result = query.OrderBy(x => x.ParentProgramOrder).ThenBy(x => x.program.ProgramOrder).ToList();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //string[] splitid = id.Split(',');
            //Privilege privilege = db.Privileges.Find(splitid[0], splitid[1], splitid[2]);
            //if (privilege == null)
            //{
            //    return HttpNotFound();
            //}
            return View(result);
        }

        // POST: /Privilege/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrivilegeProgramViewModel vm,string id)
        {
            //[Bind(Include = "CompanyID,GroupID,ProgramID,Add,Search,Modify,Delete,Print,Run,Help,Transform,CreateUserID,CreateDateTime,ModifyUserID")] Privilege privilege
            //privilege.ModifyUserID = "ADMIN";
            //privilege.ModifyDateTime = DateTime.Now;


            //if (ModelState.IsValid)
            //{
            //    db.Entry(privilege).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //var query = (from PG in db.Programs
            //             join PL in db.Privileges
            //             on new { ProgramID = PG.ProgramID } equals new { ProgramID = PL.ProgramID } into ps
            //             from PL in ps.DefaultIfEmpty()
            //             orderby PG.ProgramID
            //             select new PrivilegeEditViewModel { Program = PG, GroupID = PL.GroupID }).Distinct().ToList();
            //var result = new PrivilegeProgramViewModel
            //{
            //    ProgramEdit = query.ToPagedList(1, 999)
            //};
            
            foreach (var item in vm.ProgramEdit)
            {
                if (item.IsModify == 1)
                {
                    Privilege privilege = new Privilege();

                    privilege.CompanyID = item.privilege.CompanyID;
                    privilege.GroupID = item.privilege.GroupID;
                    privilege.ProgramID = item.privilege.ProgramID;

                    privilege.Add = item.privilege.Add;
                    privilege.Search = item.privilege.Search;
                    privilege.Modify = item.privilege.Modify;
                    privilege.Delete = item.privilege.Delete;
                    privilege.Print = item.privilege.Print;
                    privilege.Help = item.privilege.Help;
                    privilege.Transform = item.privilege.Transform;
                    privilege.Run = item.privilege.Run;

                    privilege.CreateUserID = item.privilege.CompanyID;
                    privilege.CreateDateTime = DateTime.Now;
                    privilege.ModifyUserID = item.privilege.ModifyUserID;
                    privilege.ModifyDateTime = DateTime.Now;


                    if (ModelState.IsValid)
                    {
                        db.Entry(privilege).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
			}

            var query = (from PL in db.Privileges.Where(x => x.GroupID == id)
                         join PG in db.Programs
                         on new { ProgramID = PL.ProgramID } equals new { ProgramID = PG.ProgramID } into ps
                         from PG in ps.DefaultIfEmpty()
                         join PPG in db.Programs.Where(x => x.ParentProgramID == "")
                        on PG.ParentProgramID equals PPG.ProgramID into pps
                         from PPG in pps.DefaultIfEmpty()
                         orderby PPG.ProgramOrder
                         select new PrivilegeEditViewModel
                         {
                             privilege = PL,
                             ProgDescription = PG.ProgDescription,
                             ProgramOrder = PG.ProgramOrder,
                             ParentProgramOrder = PPG.ProgramOrder,
                             ParentProgramID = PG.ParentProgramID,
                             IsModify = 0
                         }).Distinct().ToList();
            var result = new PrivilegeProgramViewModel
            {
                ProgramEdit = query.OrderBy(x => x.ParentProgramOrder).ThenBy(x => x.ProgramOrder).ToList()
            };

            return View(result);
        }

        // GET: /Privilege/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Privilege privilege = db.Privileges.Find(splitid[0], splitid[1], splitid[2]);
            if (privilege == null)
            {
                return HttpNotFound();
            }
            return View(privilege);
        }

        // POST: /Privilege/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Privilege privilege = db.Privileges.Find(splitid[0], splitid[1], splitid[2]);
            db.Privileges.Remove(privilege);
            db.SaveChanges();
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
