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
    public class APICodeController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/APICode
        public IQueryable<Code> GetCodes()
        {
            return db.Codes;
        }

        // GET api/APICode/5
        [ResponseType(typeof(Code))]
        public async Task<IHttpActionResult> GetCode(string id)
        {
            //string[] splitid = id.Split(',');
            //string Code_knid = splitid[0];
            var Code = await db.Codes.Where(x => x.Code_Kind == id).ToListAsync();            
            if (Code == null)
            {
                return NotFound();
            }

            return Ok(Code);
        }

        // PUT api/APICode/5
        public async Task<IHttpActionResult> PutCode(string id, Code Code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Code.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(Code).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeExists(id))
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

        // POST api/APICode
        [ResponseType(typeof(Code))]
        public async Task<IHttpActionResult> PostCode(Code Code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Codes.Add(Code);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CodeExists(Code.CompanyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Code.CompanyID }, Code);
        }

        // DELETE api/APICode/5
        [ResponseType(typeof(Code))]
        public async Task<IHttpActionResult> DeleteCode(string id)
        {
            Code Code = await db.Codes.FindAsync(id);
            if (Code == null)
            {
                return NotFound();
            }

            db.Codes.Remove(Code);
            await db.SaveChangesAsync();

            return Ok(Code);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CodeExists(string id)
        {
            return db.Codes.Count(e => e.CompanyID == id) > 0;
        }
    }
}