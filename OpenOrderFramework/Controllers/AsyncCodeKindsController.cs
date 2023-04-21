using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Controllers
{
    public class AsyncCodeKindsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsyncCodeKinds
        public async Task<ActionResult> Index()
        {
            if (Request.Form["submitbutton1"] != null)
            { 
            }
                
            return View(await db.CodeKinds.ToListAsync());
        }

        // GET: AsyncCodeKinds/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeKind codeKind = await db.CodeKinds.FindAsync(id);
            if (codeKind == null)
            {
                return HttpNotFound();
            }
            return View(codeKind);
        }

        // GET: AsyncCodeKinds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsyncCodeKinds/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompanyID,Code_Kind,Code_KindName,Memo,Modify_YN,CreateUserID,CreateDateTime,ModifyUserID,ModifyDateTime")] CodeKind codeKind)
        {
            if (ModelState.IsValid)
            {
                db.CodeKinds.Add(codeKind);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(codeKind);
        }

        // GET: AsyncCodeKinds/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeKind codeKind = await db.CodeKinds.FindAsync(id);
            if (codeKind == null)
            {
                return HttpNotFound();
            }
            return View(codeKind);
        }

        // POST: AsyncCodeKinds/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompanyID,Code_Kind,Code_KindName,Memo,Modify_YN,CreateUserID,CreateDateTime,ModifyUserID,ModifyDateTime")] CodeKind codeKind)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codeKind).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(codeKind);
        }

        // GET: AsyncCodeKinds/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeKind codeKind = await db.CodeKinds.FindAsync(id);
            if (codeKind == null)
            {
                return HttpNotFound();
            }
            return View(codeKind);
        }

        // POST: AsyncCodeKinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CodeKind codeKind = await db.CodeKinds.FindAsync(id);
            db.CodeKinds.Remove(codeKind);
            await db.SaveChangesAsync();
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
