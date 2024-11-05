public class Course{
    public int Id { get; set; }
    public string ?Title { get; set; }
    public int Credits { get; set; }
    public ICollection<Enrollment> ?Enrollments { get; set; }
     public Course() { }

    public Course(CourseDTO courseDTO)
    {
        Id = courseDTO.Id;
        Title = courseDTO.Title;
        Credits = courseDTO.Credits;
    }
}