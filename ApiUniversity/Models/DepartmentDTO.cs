public class DepartmentDTO{
    
    public string Name { get; set; } = null!;
    public InstructorDTO ?Administrator { get; set; }

    public DepartmentDTO() { }

    public DepartmentDTO(Department department)
    {
        
        Name = department.Name!;
        Administrator = new InstructorDTO(department.Administrator!);
    }

}