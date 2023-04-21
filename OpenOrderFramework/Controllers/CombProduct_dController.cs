using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Controllers
{
    public class CombProduct_dController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: /CombProduct_d/
        public ActionResult Index()
        {
            return View(db.CombProduct_ds.ToList());
        }

        // GET: /CombProduct_d/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CombProduct_d combproduct_d = db.CombProduct_ds.Find(splitid[0], splitid[1], splitid[2]);
            if (combproduct_d == null)
            {
                return HttpNotFound();
            }
            return View(combproduct_d);
        }

        // GET: /CombProduct_d/Create
        public ActionResult Create(string id)
        {
            string[] splitid = id.Split(',');
            string CombProductID= splitid[1];

            //帶入編號
            ViewBag.CombProductID = CombProductID;

            //帶入項次
            ViewBag.CombProdSeq = (db.CombProduct_ds.Where(x => x.CombProductID == CombProductID).Count() + 1).ToString().PadLeft(3,'0');

            return View();
        }

        // POST: /CombProduct_d/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,CombProductID,CombProdSeq,ProductID,OtherProductID,Memo,CreateUserID,ModifyUserID")] CombProduct_d combproduct_d)
        {
            combproduct_d.CompanyID = "S1";
            combproduct_d.CreateUserID = "ADMIN";
            combproduct_d.CreateDateTime = DateTime.Now;
            combproduct_d.ModifyUserID = "ADMIN";
            combproduct_d.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.CombProduct_ds.Add(combproduct_d);
                db.SaveChanges();
                return RedirectToAction("../CombProduct_m/Index");
            }

            return View(combproduct_d);
        }

        // GET: /CombProduct_d/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CombProduct_d combproduct_d = db.CombProduct_ds.Find(splitid[0], splitid[1], splitid[2]);
            if (combproduct_d == null)
            {
                return HttpNotFound();
            }
            return View(combproduct_d);
        }

        // POST: /CombProduct_d/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,CombProductID,CombProdSeq,ProductID,OtherProductID,Memo,CreateUserID,CreateDateTime,ModifyUserID")] CombProduct_d combproduct_d)
        {

            combproduct_d.ModifyUserID = "ADMIN";
            combproduct_d.ModifyDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(combproduct_d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../CombProduct_m/Index");
            }
            return View(combproduct_d);
        }

        // GET: /CombProduct_d/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] splitid = id.Split(',');
            CombProduct_d combproduct_d = db.CombProduct_ds.Find(splitid[0], splitid[1], splitid[2]);
            if (combproduct_d == null)
            {
                return HttpNotFound();
            }
            return View(combproduct_d);
        }

        // POST: /CombProduct_d/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] splitid = id.Split(',');
            CombProduct_d combproduct_d = db.CombProduct_ds.Find(splitid[0], splitid[1], splitid[2]);
            db.CombProduct_ds.Remove(combproduct_d);
            db.SaveChanges();
            return RedirectToAction("../CombProduct_m/Index");
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
