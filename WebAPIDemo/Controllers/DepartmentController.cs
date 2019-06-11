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
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class DepartmentController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: api/Department
        public IQueryable<DEPARTMENT> GetDEPARTMENTs()
        {
            return db.DEPARTMENTs;
        }

        // GET: api/Department/5
        [ResponseType(typeof(DEPARTMENT))]
        public IHttpActionResult GetDEPARTMENT(short id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }

            return Ok(dEPARTMENT);
        }

        // PUT: api/Department/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDEPARTMENT(short id, DEPARTMENT dEPARTMENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dEPARTMENT.DEPARTMENT_ID)
            {
                return BadRequest();
            }

            db.Entry(dEPARTMENT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEPARTMENTExists(id))
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

        // POST: api/Department
        [ResponseType(typeof(DEPARTMENT))]
        public IHttpActionResult PostDEPARTMENT(DEPARTMENT dEPARTMENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dEPARTMENT.DEPARTMENT_ID = (short)(db.DEPARTMENTs.Max(t => t.DEPARTMENT_ID) + 1);
            db.DEPARTMENTs.Add(dEPARTMENT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DEPARTMENTExists(dEPARTMENT.DEPARTMENT_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dEPARTMENT.DEPARTMENT_ID }, dEPARTMENT);
        }

        // DELETE: api/Department/5
        [ResponseType(typeof(DEPARTMENT))]
        public IHttpActionResult DeleteDEPARTMENT(short id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }

            db.DEPARTMENTs.Remove(dEPARTMENT);
            db.SaveChanges();

            return Ok(dEPARTMENT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DEPARTMENTExists(short id)
        {
            return db.DEPARTMENTs.Count(e => e.DEPARTMENT_ID == id) > 0;
        }
    }
}