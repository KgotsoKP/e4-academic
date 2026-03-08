using Academic.Api.Models;
using Academic.Api.ServiceErrors;
using ErrorOr;

namespace Academic.Api.Services.Students;

public class StudentService : IStudentService
{
    private static readonly Dictionary<Guid, Student> _students = new ();
    
    public ErrorOr<Created> CreateStudent(Student student)
    {
        _students.Add(student.Id, student);

        return Result.Created;
    }

    public ErrorOr<Student> GetStudent(Guid id)
    {
        if (_students.TryGetValue(id, out var student))
        {
            return student;
        };

        return Errors.Student.NotFound;
    }

    public ErrorOr<Updated> UpdateStudent(Student student, Guid id)
    {
        if (!_students.ContainsKey(id))
        {
            return Errors.Student.NotFound;
        }
        
        _students[id] = student;
        
        return Result.Updated;
    }

    public ErrorOr<Deleted> DeleteStudent(Guid id)
    {
        if (!_students.ContainsKey(id))
        {
            return Errors.Student.NotFound;
        }
        
        _students.Remove(id);
        
        return Result.Deleted;
    }
}