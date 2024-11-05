public class Enrollment{
    public int Id { get; set; }
    public Grade? Grade { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student ?Student { get; set; }
    public Course ?Course { get; set; }

    public Enrollment() { }
    public Enrollment(DetailedEnrollmentDTO detailedEnrollmentDTO)
    {
        Id = detailedEnrollmentDTO.Id;
        Grade = detailedEnrollmentDTO.Grade;
        Student= new Student(detailedEnrollmentDTO.Student!);
        Course = new Course(detailedEnrollmentDTO.Course!);
    }
    public Enrollment(EnrollmentDTO enrollmentDTO)
    {
        Id = enrollmentDTO.Id;
        Grade = enrollmentDTO.Grade;
        StudentId = enrollmentDTO.StudentId;
        CourseId = enrollmentDTO.CourseId;
    }
}