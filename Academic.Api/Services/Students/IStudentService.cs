using Academic.Api.Models;
using ErrorOr;

namespace Academic.Api.Services.Students;

public interface IStudentService
{
    ErrorOr<Created> CreateStudent(Student student);
    ErrorOr<Student> GetStudent(Guid id);
    ErrorOr<IEnumerable<Student>> GetStudents();
    ErrorOr<Updated> UpdateStudent(Student student, Guid id);
    ErrorOr<Deleted> DeleteStudent(Guid id);
}