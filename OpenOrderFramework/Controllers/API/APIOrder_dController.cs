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
using System.Web.Http.Cors;

namespace OpenOrderFramework.Controllers
{
    [EnableCors(origins: "http://ac33467790.azurewebsites.net", headers: "*", methods: "*")]
    public class APIOrder_dController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/APIOrder_d
        public IQueryable<Order_d> GetOrder_ds()
        {
            return db.Order_ds;
        }

        // GET api/APIOrder_d/5
        [ResponseType(typeof(Order_d))]
        public async Task<IHttpActionResult> GetOrder_d(string id)
        {
            Order_d order_d = await db.Order_ds.FindAsync(id);
            if (order_d == null)
            {
                return NotFound();
            }

            return Ok(order_d);
        }

        // PUT api/APIOrder_d/5
        public async Task<IHttpActionResult> PutOrder_d(string id, Order_d order_d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_d.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(order_d).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_dExists(id))
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

        // POST api/APIOrder_d
        [ResponseType(typeof(Order_d))]
        public async Task<IHttpActionResult> PostOrder_d(Order_d order_d)
        {
            //Order_d order_d = new Order_d();
            //序號自己編
            int order_seq = db.Order_ds.Where(x => x.CompanyID == order_d.CompanyID & x.OrderNo == order_d.OrderNo).Count();
            //order_d.OrderSeq = order_seq.ToString();
            //order_d.CompanyID = CompanyID;
            //order_d.OrderNo = OrderNo;
            //order_d.Qty = Qty;
            //order_d.Memo = Memo;
            //order_d.Temperature = Temperature;
            //order_d.Sugar = Sugar;
            //order_d.Size = Size;
            

            order_d.CreateDateTime = DateTime.Now;
            order_d.ModifyDateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order_ds.Add(order_d);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Order_dExists(order_d.CompanyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order_d.CompanyID }, order_d);
        }

        // DELETE api/APIOrder_d/5
        [ResponseType(typeof(Order_d))]
        public async Task<IHttpActionResult> DeleteOrder_d(string id)
        {
            Order_d order_d = await db.Order_ds.FindAsync(id);
            if (order_d == null)
            {
                return NotFound();
            }

            db.Order_ds.Remove(order_d);
            await db.SaveChangesAsync();

            return Ok(order_d);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Order_dExists(string id)
        {
            return db.Order_ds.Count(e => e.CompanyID == id) > 0;
        }
    }
}