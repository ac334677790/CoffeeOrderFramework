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
    public class CoffeeController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Coffee
        public IQueryable<Order_m> GetOrder_ms()
        {
            return db.Order_ms;
        }

        // GET api/Coffee/5
        [ResponseType(typeof(Order_m))]
        public async Task<IHttpActionResult> GetOrder_m(string id)
        {
            string[] splitid = id.Split(',');
            Order_m order_m = await db.Order_ms.FindAsync(splitid[0], splitid[1]);
            if (order_m == null)
            {
                return NotFound();
            }

            return Ok(order_m);
        }

        // PUT api/Coffee/5
        public async Task<IHttpActionResult> PutOrder_m(string id, Order_m order_m)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_m.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(order_m).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_mExists(id))
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

        // POST api/Coffee
        [ResponseType(typeof(Order_m))]
        public async Task<IHttpActionResult> PostOrder_m(Order_m order_m)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order_ms.Add(order_m);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Order_mExists(order_m.CompanyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order_m.CompanyID }, order_m);
        }

        // DELETE api/Coffee/5
        [ResponseType(typeof(Order_m))]
        public async Task<IHttpActionResult> DeleteOrder_m(string id)
        {
            Order_m order_m = await db.Order_ms.FindAsync(id);
            if (order_m == null)
            {
                return NotFound();
            }

            db.Order_ms.Remove(order_m);
            await db.SaveChangesAsync();

            return Ok(order_m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Order_mExists(string id)
        {
            return db.Order_ms.Count(e => e.CompanyID == id) > 0;
        }
    }
}