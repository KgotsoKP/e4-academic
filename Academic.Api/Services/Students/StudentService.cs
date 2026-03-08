using Academic.Api.Models;
using Academic.Contracts;

namespace Academic.Api.Services.Students;

// Use EF core and Repository
public class StudentService : IStudentService
{
    private static readonly Dictionary<Guid, Student> _students = new ();
    
    public void CreateStudent(Student student)
    {
        _students.Add(student.Id, student);
    }

    public Student GetStudent(Guid id)
    {
        return _students[id];
    }

    public void UpdateStudent(Student student, Guid id)
    {
        _students[id] = student;
    }

    public void DeleteStudent(Guid id)
    {
        _students.Remove(id);
    }
}