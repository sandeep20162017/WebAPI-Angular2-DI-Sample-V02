using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ASPNET5WEBAPIAngularJS.Models;

namespace ASPNET5WEBAPIAngularJS.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentMasters")]
    public class StudentMastersController : Controller
    {
        private StudentMastersAppContext _context;

        public StudentMastersController(StudentMastersAppContext context)
        {
            _context = context;
        }
        // GET: api/StudentMasters
        [HttpGet]
        public IEnumerable<StudentMasters> GetStudents()
        {
            return _context.Students;
        }

        // GET: api/StudentMasters/5
        [HttpGet("{id}", Name = "GetStudentMasters")]
        public IActionResult GetStudentMasters([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StudentMasters studentMasters = _context.Students.Single(m => m.StdID == id);

            if (studentMasters == null)
            {
                return HttpNotFound();
            }

            return Ok(studentMasters);
        }

        // PUT: api/StudentMasters/5
        [HttpPut("{id}")]
        public IActionResult PutStudentMasters(int id, [FromBody] StudentMasters studentMasters)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != studentMasters.StdID)
            {
                return HttpBadRequest();
            }

            _context.Entry(studentMasters).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMastersExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/StudentMasters
        [HttpPost]
        public IActionResult PostStudentMasters([FromBody] StudentMasters studentMasters)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Students.Add(studentMasters);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentMastersExists(studentMasters.StdID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetStudentMasters", new { id = studentMasters.StdID }, studentMasters);
        }

        // DELETE: api/StudentMasters/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentMasters(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StudentMasters studentMasters = _context.Students.Single(m => m.StdID == id);
            if (studentMasters == null)
            {
                return HttpNotFound();
            }

            _context.Students.Remove(studentMasters);
            _context.SaveChanges();

            return Ok(studentMasters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentMastersExists(int id)
        {
            return _context.Students.Count(e => e.StdID == id) > 0;
        }
    }
}