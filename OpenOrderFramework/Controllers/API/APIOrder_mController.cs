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
    public class APIOrder_mController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/APIOrder_m
        public IQueryable<Order_m> GetOrder_ms()
        {
            return db.Order_ms;
        }

        // GET api/APIOrder_m/5
        [Route("api/APIOrder_m/{id}", Name = "GetOrder_m")]
        [ResponseType(typeof(Order_m))]
        public async Task<IHttpActionResult> GetOrder_m(string id)
        {
            string[] splitid = id.Split(',');
            if (splitid.Length == 1) {
                var orderList = await db.Order_ms.Where(x => x.CustomerID == id).OrderByDescending(x => x.CreateDateTime).ToListAsync();
                return Ok(orderList);
            }

            Order_m order_m = await db.Order_ms.FindAsync(splitid[0], splitid[1]);
            if (order_m == null)
            {
                return NotFound();
            }

            return Ok(order_m);
        }

        // PUT api/APIOrder_m/5
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

        // POST api/APIOrder_m
        [ResponseType(typeof(Order_m))]
        public async Task<IHttpActionResult> PostOrder_m(Order_m order_m)
        {

            ////Order_m order_m = new Order_m();

            //單號自己編
            int order_no = db.Order_ms.Where(x => x.CompanyID == order_m.CompanyID).Count();
            order_m.OrderNo = order_no.ToString();

            //order_m.CompanyID = Torder_m.CompanyID;
            ////order_m.CustomerID = Torder_m.CustomerID;
            ////order_m.CustName = Torder_m.CustName;
            ////order_m.ContactName = Torder_m.ContactName;
            ////order_m.TelephoneNumber = Torder_m.TelephoneNumber;
            ////order_m.MobileNumber = Torder_m.MobileNumber;
            ////order_m.Email = Torder_m.Email;
            ////order_m.PayKind = Torder_m.PayKind;
            ////order_m.DeliveryAddress = Torder_m.DeliveryAddress;
            ////order_m.Memo = Torder_m.Memo;
            ////order_m.OrderDateTime = Torder_m.OrderDateTime;
            ////order_m.Promotional = Torder_m.Promotional;

            order_m.CreateDateTime = DateTime.Now;
            order_m.ModifyDateTime = DateTime.Now;

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

            return CreatedAtRoute("GetOrder_m", new { id = order_m.CompanyID + ',' + order_m.OrderNo }, order_m);
        }

        // DELETE api/APIOrder_m/5
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