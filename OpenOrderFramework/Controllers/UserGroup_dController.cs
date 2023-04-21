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
    public class UserGroup_dController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //定義下拉字典
        private Dictionary<string, string> GetAllUserGroup_m()
        {
            var query = db.UserGroup_ms.OrderBy(x => x.GroupID);
            return query.ToDictionary(x => x.GroupID.ToString(), x => x.GroupDOC);
        }


        [Authorize]
        // GET: /UserGroup_d/
        public ActionResult Index()
        {
            return View(db.UserGroup_ds.ToList());
        }

        // GET: /UserGroup_d/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            UserGroup_d usergroup_d = db.UserGroup_ds.Find(splitid[0], splitid[1], splitid[2]);
            if (usergroup_d == null)
            {
                return HttpNotFound();
            }
            return View(usergroup_d);
        }

        // GET: /UserGroup_d/Create
        public ActionResult Create(string id)
        {
            GetDropDownList(id);

            return View();
        }

        private void GetDropDownList(string id)
        {
            //下拉帶入ViewBag
            var userGroup_ms = this.GetAllUserGroup_m();

            string[] splitid = id.Split(',');

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var userGroup_m in userGroup_ms)
            {
                items.Add(new SelectListItem()
                {
                    Text = userGroup_m.Value,
                    Value = userGroup_m.Key,
                    Selected = userGroup_m.Key.Equals(splitid[1])
                });
            }
            ViewBag.UserGroup_ms = items;
        }

        // POST: /UserGroup_d/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,GroupID,UserID,CreateUserID,ModifyUserID")] UserGroup_d usergroup_d)
        {
            usergroup_d.CompanyID = "S1";
            usergroup_d.CreateUserID = "ADMIN";
            usergroup_d.CreateDateTime = DateTime.Now;
            usergroup_d.ModifyUserID = "ADMIN";
            usergroup_d.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.UserGroup_ds.Add(usergroup_d);
                db.SaveChanges();
                return RedirectToAction("../UserGroup_m/Index");
            }

            return View(usergroup_d);
        }

        // GET: /UserGroup_d/Edit/5
        public ActionResult Edit(string id)
        {
            GetDropDownList(id);

            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string GroupID = splitid[1];

            var query = (from U in db.Users.Where(x => x.CompanyID == CompanyID)
                         join UGD in db.UserGroup_ds.Where(x => x.GroupID == GroupID)
                         on new { UserID = U.UserID } equals new { UserID = UGD.UserID } into ps
                         from UGD in ps.DefaultIfEmpty()
                         orderby U.UserID
                         select new UserGroup_dEditViewModel
                         {
                             users = U,
                             state = UGD != null ? UserGroup_dEditViewModel.STATE.MODIFY : UserGroup_dEditViewModel.STATE.NOTHING
                         }).Distinct().ToList();
            var result = new UserGroup_dViewModel
            {
                UserGroup_dEdit = query.ToList()
            };

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //string[] splitid = id.Split(',');
            //UserGroup_d usergroup_d = db.UserGroup_ds.Find(splitid[0], splitid[1], splitid[2]);
            //if (usergroup_d == null)
            //{
            //    return HttpNotFound();
            //}
            return View(result);
        }

        // POST: /UserGroup_d/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserGroup_dViewModel vm,string id)
        {
            //usergroup_d.ModifyUserID = "ADMIN";
            //usergroup_d.ModifyDateTime = DateTime.Now;


            //if (ModelState.IsValid)
            //{
            //    db.Entry(usergroup_d).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("../UserGroup_m/Index");
            //}
            //return View(usergroup_d);


            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string GroupID = splitid[1];

            foreach (var item in vm.UserGroup_dEdit)
            {
                if (item.state == UserGroup_dEditViewModel.STATE.INSERT)
                {
                    UserGroup_d usergroup_d = new UserGroup_d();

                    usergroup_d.CompanyID = CompanyID;
                    usergroup_d.GroupID = GroupID;
                    usergroup_d.UserID = item.users.UserID;
                    usergroup_d.CreateUserID = "ADMIN";
                    usergroup_d.CreateDateTime = DateTime.Now;
                    usergroup_d.ModifyUserID = "ADMIN";
                    usergroup_d.ModifyDateTime = DateTime.Now;


                    //if (ModelState.IsValid)
                    //{
                        db.UserGroup_ds.Add(usergroup_d);
                        db.SaveChanges();
                    //}
                }
                if (item.state == UserGroup_dEditViewModel.STATE.DELETE)
                {
                    UserGroup_d usergroup_d = db.UserGroup_ds.Find(CompanyID, GroupID, item.users.UserID);
                    db.UserGroup_ds.Remove(usergroup_d);
                    db.SaveChanges();
                }
            }


            var query = (from U in db.Users.Where(x => x.CompanyID == CompanyID)
                         join UGD in db.UserGroup_ds.Where(x => x.GroupID == GroupID)
                         on new { UserID = U.UserID } equals new { UserID = UGD.UserID } into ps
                         from UGD in ps.DefaultIfEmpty()
                         orderby U.UserID
                         select new UserGroup_dEditViewModel
                         {
                             users = U,
                             state = UGD != null ? UserGroup_dEditViewModel.STATE.MODIFY : UserGroup_dEditViewModel.STATE.NOTHING
                         }).Distinct().ToList();
            var result = new UserGroup_dViewModel
            {
                UserGroup_dEdit = query.OrderBy(x => x.users.UserID).ToList()
            };

            return View(result);
        }

        // GET: /UserGroup_d/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            UserGroup_d usergroup_d = db.UserGroup_ds.Find(splitid[0], splitid[1], splitid[2]);
            if (usergroup_d == null)
            {
                return HttpNotFound();
            }
            return View(usergroup_d);
        }

        // POST: /UserGroup_d/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            UserGroup_d usergroup_d = db.UserGroup_ds.Find(splitid[0], splitid[1], splitid[2]);
            db.UserGroup_ds.Remove(usergroup_d);
            db.SaveChanges();
            return RedirectToAction("../UserGroup_m/Index");
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
