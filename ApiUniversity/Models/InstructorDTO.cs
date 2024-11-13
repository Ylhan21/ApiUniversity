public class InstructorDTO{

    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime HireDate { get; set; }

    public InstructorDTO() { }

    public InstructorDTO(Instructor instructor)
    {
        
        LastName = instructor.LastName!;
        FirstName = instructor.FirstName!;
        HireDate = instructor.HireDate;
    }
}