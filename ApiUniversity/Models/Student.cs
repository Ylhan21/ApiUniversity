public class Student{
    public int Id { get; set; }
    public string ?LastName { get; set; }
    public string ?FirstName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public ICollection<Enrollment> ?Enrollments { get; set; }
    public Student() { }
    public Student(StudentDTO studentDTO)
    {
        Id = studentDTO.Id;
        LastName = studentDTO.LastName;
        FirstName = studentDTO.FirstName;
        EnrollmentDate = studentDTO.EnrollmentDate;
    }
}