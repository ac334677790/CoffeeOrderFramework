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
    public class Order_d_tranController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Order_d_tran/
        public ActionResult Index()
        {
            return View(db.Order_d_trans.ToList());
        }

        // GET: /Order_d_tran/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_d_tran order_d_tran = db.Order_d_trans.Find(id);
            if (order_d_tran == null)
            {
                return HttpNotFound();
            }
            return View(order_d_tran);
        }

        // GET: /Order_d_tran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Order_d_tran/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompanyID,OrderNo,OrderSeq,TranDateTime,QuoteNo,QuoteSeq,ProductID,ProdName,ProdSpec,Qty,ProdUnit,CostPrice,UnitPrice,Discount,Total,Memo,OrderStatus,DataStatus,EndCode_YN,Temperature,Sugar,Size,CreateUserID,CreateDateTime,ModifyUserID,ModifyDateTime")] Order_d_tran order_d_tran)
        {
            if (ModelState.IsValid)
            {
                db.Order_d_trans.Add(order_d_tran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order_d_tran);
        }

        // GET: /Order_d_tran/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_d_tran order_d_tran = db.Order_d_trans.Find(id);
            if (order_d_tran == null)
            {
                return HttpNotFound();
            }
            return View(order_d_tran);
        }

        // POST: /Order_d_tran/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompanyID,OrderNo,OrderSeq,TranDateTime,QuoteNo,QuoteSeq,ProductID,ProdName,ProdSpec,Qty,ProdUnit,CostPrice,UnitPrice,Discount,Total,Memo,OrderStatus,DataStatus,EndCode_YN,Temperature,Sugar,Size,CreateUserID,CreateDateTime,ModifyUserID,ModifyDateTime")] Order_d_tran order_d_tran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_d_tran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order_d_tran);
        }

        // GET: /Order_d_tran/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_d_tran order_d_tran = db.Order_d_trans.Find(id);
            if (order_d_tran == null)
            {
                return HttpNotFound();
            }
            return View(order_d_tran);
        }

        // POST: /Order_d_tran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order_d_tran order_d_tran = db.Order_d_trans.Find(id);
            db.Order_d_trans.Remove(order_d_tran);
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
