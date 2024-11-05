using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly UniversityContext _context;

    public StudentController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/student
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
    {
        
        var students = _context.Students.Select(x => new StudentDTO(x));;
        return await students.ToListAsync();
    }
// GET: api/student/2
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDTO>> GetStudent(int id)
    {
        
        var student = await _context.Students.SingleOrDefaultAsync(t => t.Id == id);

        if (student == null)
            return NotFound();

        return new StudentDTO(student);
    }

    // POST: api/student
    [HttpPost]
    public async Task<ActionResult<StudentDTO>> PostStudent(StudentDTO studentDTO)
    {
        Student student = new(studentDTO);
        
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, new StudentDTO(student));
    }

    // PUT: api/student/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, StudentDTO studentDTO)
    {
        if (id != studentDTO.Id)
        {
            return BadRequest();
        }

        Student student = new(studentDTO);
        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Students.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/student/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentItem(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}