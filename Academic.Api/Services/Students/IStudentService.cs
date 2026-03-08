using Academic.Api.Models;
using Academic.Contracts;

namespace Academic.Api.Services.Students;

public interface IStudentService
{
    void CreateStudent(Student student);
    Student GetStudent(Guid id);
    void UpdateStudent(Student student, Guid id);
    void DeleteStudent(Guid id);
}