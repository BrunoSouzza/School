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
                var newStudent = _context.Students.Add(studentAddModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStudent", new { id = newStudent.Entity.Id }, newStudent.Entity);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { err = "Student already exists" });
            }
            catch (Exception)
            {
                return BadRequest(new { err = "Could not save student" });
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null)
                return NotFound();

            return Ok(student);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModel()
        {
            if (_context.Students == null)
                return NotFound();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(int id, StudentModel studentModel)
        {
            if (id != studentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
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
            
            var studentModel = await _context.Students.FindAsync(id);
            if (studentModel == null)
                return NotFound();

            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentModelExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
