public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? InstructorId { get; set; }
    public Instructor? Administrator { get; set; }
    public ICollection<Course> ?Courses { get; set; }
    public Department() { }

    public Department(DepartmentDTO departmentDTO)
    {
        
        Name = departmentDTO.Name;
        Administrator = new Instructor(departmentDTO.Administrator!);
    }

}