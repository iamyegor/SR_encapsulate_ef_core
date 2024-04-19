namespace EFCoreEncapsulation.Api;

public class StudentRepository
{
    private readonly SchoolContext _context;

    public StudentRepository(SchoolContext context)
    {
        _context = context;
    }

    public Student GetById(long id)
    {
        Student student = _context.Students.Find(id);

        if (student == null)
            return null;

        _context.Entry(student).Collection(x => x.Enrollments).Load();
        _context.Entry(student).Collection(x => x.SportsEnrollments).Load();

        return student;
    }

    public void Save(Student student)
    {
        // Use one of:

        _context.Students.Add(student);
        _context.Students.Update(student);
        _context.Students.Attach(student);
    }
}

public class CourseRepository
{
    private readonly SchoolContext _context;

    public CourseRepository(SchoolContext context)
    {
        _context = context;
    }

    public Course GetById(long id)
    {
        Course course = _context.Courses.Find(id);
        return course;
    }

    public void Save(Course course)
    {
        _context.Courses.Add(course);
    }
}
