using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackAssignmentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        DbModel db;

        public CourseController(DbModel db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return db.Courses.OrderBy(c => c.CourseName).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var course = db.Courses.SingleOrDefault(c => c.CourseID == id);

            if(course == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(course);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Course course)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = course.CourseID }, course);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = course.CourseID }, course);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var course = db.Courses.SingleOrDefault(c => c.CourseID == id);

            if(course == null)
            {
                return NotFound();
            }
            else
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
