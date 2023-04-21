using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OpenOrderFramework.Models;
using System.Web.Http.Cors;

namespace OpenOrderFramework.Controllers
{
    [EnableCors(origins: "http://ac33467790.azurewebsites.net", headers: "*", methods: "*")]
    public class APICustomerController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/APICustomer
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        // GET api/APICustomer/5
        [ResponseType(typeof(Customer))]
        [Route("api/APICustomer/{id}", Name = "GetCustomer")]
        public IHttpActionResult GetCustomer(string id)
        {
            string[] splitid = id.Split(',');
            if (splitid.Length == 2) 
            {
                string CustomerID = splitid[0];
                string Password = splitid[1];
                var customerLogin = db.Customers.Where(x => x.CustomerID == CustomerID && x.CustPassword == Password).ToList();
                return Ok(customerLogin);
            }

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT api/APICustomer/5
        public IHttpActionResult PutCustomer(string id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST api/APICustomer
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetCustomer", new { id = customer.CustomerID }, customer);
        }

        // DELETE api/APICustomer/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(string id)
        {
            return db.Customers.Count(e => e.CustomerID == id) > 0;
        }
    }
}