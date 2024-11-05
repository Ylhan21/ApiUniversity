using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly UniversityContext _context;

    public EnrollmentController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/course
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetailedEnrollmentDTO>>> GetEnrollment()
    {
        // Get courses and related lists
        var enrollments = _context.Enrollments.Include(x=>x.Course).Include(x=>x.Student).Select(x => new DetailedEnrollmentDTO(x));;
        return await enrollments.ToListAsync();
    }

    // GET: api/enrollment/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedEnrollmentDTO>> GetEnrollment(int id)
    {
        
        var enrollment = await _context.Enrollments.Include(x=>x.Course).Include(x=>x.Student).SingleOrDefaultAsync(t => t.Id == id);

        if (enrollment == null)
        {
            return NotFound();
        }

        return new DetailedEnrollmentDTO(enrollment);
    }
    // POST: api/enrollment
    [HttpPost]
    public async Task<ActionResult<Enrollment>> PostEnrollment(EnrollmentDTO enrollmentDTO)
    {
        Enrollment enrollment = new(enrollmentDTO);
        
        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, new EnrollmentDTO(enrollment));
    }

}