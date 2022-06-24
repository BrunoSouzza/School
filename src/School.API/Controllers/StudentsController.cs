using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Context;
using School.API.Models;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudent(StudentAddModel studentAddModel)
        {
            try
            {
                var course = _context.Courses.Find(studentAddModel.CourseId);
                if (course is null)
                    return NotFound(new { error = "Course not found" });

                var newStudent = _context.Students.Add(studentAddModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStudent", new { id = newStudent.Entity.Id }, newStudent.Entity);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { error = "Student already exists" });
            }
            catch (Exception)
            {
                return BadRequest(new { error = "Could not save student" });
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var student = await _context.Students
                                        .Include(c => c.Course)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
        {
            if (_context.Students == null)
                return NotFound();

            return Ok(await _context.Students.Include(c => c.Course).ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentUpdateModel studentUpdateModel)
        {
            if (id != studentUpdateModel.Id)
                return BadRequest();
            
            try
            {
                var student = await _context.Students.SingleOrDefaultAsync(c => c.Id == id);
                if (student is null)
                    return NotFound();

                student.Update(studentUpdateModel.Name, studentUpdateModel.Registered);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
