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
    public class APICustController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/APICust
        public IQueryable<Customer> GetCusts()
        {
            return db.Customers;
        }

        // GET api/APICust/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetCust(string id)
        {
            Customer cust = await db.Customers.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }

        // PUT api/APICust/5
        public async Task<IHttpActionResult> PutCust(string id, Customer cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cust.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(cust).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustExists(id))
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

        // POST api/APICust
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCust(Customer cust)
        {
            cust.ValidDate = DateTime.Now;
            cust.InValidDate = DateTime.MaxValue;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(cust);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustExists(cust.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cust.CustomerID }, cust);
        }

        // DELETE api/APICust/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCust(string id)
        {
            Customer cust = await db.Customers.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }

            db.Customers.Remove(cust);
            await db.SaveChangesAsync();

            return Ok(cust);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustExists(string id)
        {
            return db.Customers.Count(e => e.CustomerID == id) > 0;
        }
    }
}