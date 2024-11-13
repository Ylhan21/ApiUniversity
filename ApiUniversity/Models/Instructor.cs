public class Instructor
{
    public int Id { get; set; }
    public string ?LastName { get; set; }
    public string ?FirstName { get; set; }  
    public DateTime HireDate { get; set; }
    public ICollection<Course> ?Courses { get; set; }
    public ICollection<Department> ?AdministeredDepartments { get; set; }

    public Instructor() { }

    public Instructor(InstructorDTO instructorDTO)
    {
        
        LastName = instructorDTO.LastName;
        FirstName = instructorDTO.FirstName;
        HireDate = instructorDTO.HireDate;
    }
}