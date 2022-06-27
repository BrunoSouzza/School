using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Context;
using School.API.Models;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
            Console.WriteLine("TESTANDO");
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> PostCourse(CourseAddModel course)
        {
            try
            {
                var newCourse = _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCourse", new { id = newCourse.Entity.Id }, newCourse.Entity);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest( new { error = "Course already exists" });
            }
            catch (Exception)
            {
                return BadRequest(new { error = "Could not save course" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course is null)
                return NotFound();

            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourses()
        {
            if (_context.Courses == null)
                return NotFound();

            return Ok(await _context.Courses.Include(c => c.Students).ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseUpdateModel courseUpdateModel)
        {
            if (id != courseUpdateModel.Id)
                return BadRequest();

            try
            {
                var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
                if (course is null)
                    return NotFound();

                course.Update(courseUpdateModel.Name);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (_context.Courses == null)
                return NotFound();
            
            var course = await _context.Courses.FindAsync(id);
            
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
