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
    public class CodeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //定義下拉字典
        private Dictionary<string, string> GetAllCode_Kind()
        {
            var query = db.CodeKinds.OrderBy(x => x.Code_Kind);
            return query.ToDictionary(x => x.Code_Kind.ToString(), x => x.Code_KindName);
        }

        //定義下拉字典
        private Dictionary<string, string> GetAllCodeYN()
        {
            var query = db.Codes.Where(x => x.Code_Kind == "YN").OrderBy(x => x.CodeID);
            return query.ToDictionary(x => x.CodeID.ToString(), x => x.CodeName);
        }


        [Authorize]
        // GET: /Code/
        public ActionResult Index(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string Code_Kind = splitid[1];
            ViewBag.Code_Kind = Code_Kind;
            ViewBag.CompanyID = CompanyID;
            var query = db.Codes.Where(x => x.Code_Kind == Code_Kind).OrderBy(x => x.CodeID);

            var model = new CodeListViewModel
            {
                Codes = query.ToPagedList(1, 99)

            };
            return View(model);
        }

        // GET: /Code/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Code Code = db.Codes.Find(splitid[0], splitid[1],splitid[2]);
            if (Code == null)
            {
                return HttpNotFound();
            }
            return View(Code);
        }

        // GET: /Code/Create
        public ActionResult Create(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string Code_Kind = splitid[1];
            ViewBag.Code_Kind = Code_Kind;
            ViewBag.CompanyID = CompanyID;

            GetDropDownList(Code_Kind);

            return View();
        }

        private void GetDropDownList(string id)
        {
            //下拉帶入ViewBag
            var Code_Kinds = this.GetAllCode_Kind();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Code_Kind in Code_Kinds)
            {
                items.Add(new SelectListItem()
                {
                    Text = Code_Kind.Value,
                    Value = Code_Kind.Key,
                    Selected = Code_Kind.Key.Equals(id)
                });
            }
            ViewBag.Code_Kinds = items;

            //下拉帶入ViewBag
            var CodeYNs = this.GetAllCodeYN();

            items = new List<SelectListItem>();
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

        // POST: /Code/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,Code_Kind,CodeID,CodeName,Code1,Code2,Memo,Modify_YN,CreateUserID,ModifyUserID")] Code Code)
        {
            Code.CompanyID = "S1";
            Code.CreateUserID = "ADMIN";
            Code.CreateDateTime = DateTime.Now;
            Code.ModifyUserID = "ADMIN";
            Code.ModifyDateTime = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Codes.Add(Code);
                db.SaveChanges();
                return RedirectToAction("../CodeKind/Index");
            }

            return View(Code);
        }

        // GET: /Code/Edit/5
        public ActionResult Edit(string id)
        {
            string[] splitid = id.Split(',');
            string CompanyID = splitid[0];
            string Code_Kind = splitid[1];
            ViewBag.Code_Kind = Code_Kind;
            ViewBag.CompanyID = CompanyID;

            GetDropDownList(Code_Kind);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code Code = db.Codes.Find(splitid[0], splitid[1], splitid[2]);
            if (Code == null)
            {
                return HttpNotFound();
            }
            return View(Code);
        }

        // POST: /Code/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,Code_Kind,CodeID,CodeName,Code1,Code2,Memo,Modify_YN,CreateUserID,CreateDateTime,ModifyUserID")] Code Code)
        {
            Code.ModifyUserID = "ADMIN";
            Code.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(Code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../CodeKind/Index");
            }
            return View(Code);
        }

        // GET: /Code/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            Code Code = db.Codes.Find(splitid[0], splitid[1], splitid[2]);
            if (Code == null)
            {
                return HttpNotFound();
            }
            return View(Code);
        }

        // POST: /Code/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            Code Code = db.Codes.Find(splitid[0], splitid[1], splitid[2]);
            db.Codes.Remove(Code);
            db.SaveChanges();
            return RedirectToAction("../CodeKind/Index");
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
