using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Controllers
{
    public class APILongOrder_mController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/APILongOrder_m
        public IQueryable<LongOrder_m> GetLongOrder_ms()
        {
            return db.LongOrder_ms;
        }

        // GET api/APILongOrder_m/5
        [ResponseType(typeof(LongOrder_m))]
        public async Task<IHttpActionResult> GetLongOrder_m(string id)
        {
            LongOrder_m longorder_m = await db.LongOrder_ms.FindAsync(id);
            if (longorder_m == null)
            {
                return NotFound();
            }

            return Ok(longorder_m);
        }

        // PUT api/APILongOrder_m/5
        public async Task<IHttpActionResult> PutLongOrder_m(string id, LongOrder_m longorder_m)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != longorder_m.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(longorder_m).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LongOrder_mExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/APILongOrder_m
        [ResponseType(typeof(LongOrder_m))]
        public async Task<IHttpActionResult> PostLongOrder_m(LongOrder_m longorder_m)
        {
            //LongOrder_m longorder_m = new LongOrder_m();
            int long_order_no = db.LongOrder_ms.Where(x => x.CompanyID == longorder_m.CompanyID).Count();
            longorder_m.LongOrderNo = long_order_no.ToString();

            //longorder_m.OrderNo = OrderNo;
            //longorder_m.DatetimeS = DatetimeS;
            //longorder_m.CycleDay1 = CycleDay1;
            //longorder_m.CycleDay2 = CycleDay2;
            //longorder_m.CycleDay3 = CycleDay3;
            //longorder_m.CycleDay4 = CycleDay4;
            //longorder_m.CycleDay5 = CycleDay5;
            //longorder_m.CycleDay6 = CycleDay6;
            //longorder_m.CycleDay7 = CycleDay7;
            //longorder_m.CycleWeek = CycleWeek;
            //longorder_m.CycleMonth = CycleMonth;
            //longorder_m.CycleHour = CycleHour;
            //longorder_m.Memo = Memo;
            longorder_m.CreateDateTime = DateTime.Now;
            longorder_m.ModifyDateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LongOrder_ms.Add(longorder_m);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LongOrder_mExists(longorder_m.CompanyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = longorder_m.CompanyID }, longorder_m);
        }

        // DELETE api/APILongOrder_m/5
        [ResponseType(typeof(LongOrder_m))]
        public async Task<IHttpActionResult> DeleteLongOrder_m(string id)
        {
            LongOrder_m longorder_m = await db.LongOrder_ms.FindAsync(id);
            if (longorder_m == null)
            {
                return NotFound();
            }

            db.LongOrder_ms.Remove(longorder_m);
            await db.SaveChangesAsync();

            return Ok(longorder_m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LongOrder_mExists(string id)
        {
            return db.LongOrder_ms.Count(e => e.CompanyID == id) > 0;
        }
    }
}