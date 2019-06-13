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
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: api/Employee
        public IQueryable<EMPLOYEE> GetEMPLOYEEs()
        {
            return db.EMPLOYEEs;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(EMPLOYEE))]
        public IHttpActionResult GetEMPLOYEE(short id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            return Ok(eMPLOYEE);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLOYEE(short id, EMPLOYEE eMPLOYEE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLOYEE.EMPLOYEE_ID)
            {
                return BadRequest();
            }

            db.Entry(eMPLOYEE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLOYEEExists(id))
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

        // POST: api/Employee
        [ResponseType(typeof(EMPLOYEE))]
        public IHttpActionResult PostEMPLOYEE(EMPLOYEE eMPLOYEE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            eMPLOYEE.EMPLOYEE_ID = (short)(db.EMPLOYEEs.Max(t => t.EMPLOYEE_ID) + 1);
            db.EMPLOYEEs.Add(eMPLOYEE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EMPLOYEEExists(eMPLOYEE.EMPLOYEE_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eMPLOYEE.EMPLOYEE_ID }, eMPLOYEE);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(EMPLOYEE))]
        public IHttpActionResult DeleteEMPLOYEE(short id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            db.EMPLOYEEs.Remove(eMPLOYEE);
            db.SaveChanges();

            return Ok(eMPLOYEE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLOYEEExists(short id)
        {
            return db.EMPLOYEEs.Count(e => e.EMPLOYEE_ID == id) > 0;
        }

        [Route("EmployeeOnly/{empID:int}")]
        public IHttpActionResult GetEmployeeOnly(int empID)
        {
            return Ok(db.EMPLOYEEs.Select(t => new EmployeeOnly
            {
                EMPLOYEE_ID = t.EMPLOYEE_ID,
                EMPLOYEE_NAME = t.EMPLOYEE_NAME,
                EMPLOYEE_SALARY = t.EMPLOYEE_SALARY,
                EMPLOYEE_DEPARTMENT = t.EMPLOYEE_DEPARTMENT
            }).Where(t => t.EMPLOYEE_ID == empID));
        }
    }
}