using Academic.Api.Models;
using Academic.Api.ServiceErrors;
using ErrorOr;

namespace Academic.Api.Services.Students;

public class StudentService : IStudentService
{
    private static readonly Dictionary<Guid, Student> _students = SeedStudentsDictionary();

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
        }

        return Errors.Student.NotFound;
    }
    
    public ErrorOr<IEnumerable<Student>> GetStudents()
    {
        return _students.Values.ToList();
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
    
    private static Dictionary<Guid, Student> SeedStudentsDictionary()
    {
        var students = new Student[]
        {
            new(
                Guid.NewGuid(),
                "STU-20240001",
                "Thabo",
                "Molefe",
                DateTime.UtcNow,
                new List<string> { "Rugby", "Chess Club" },
                new List<string> { "Computer Science 101", "Calculus I", "Academic Literacy" }
            ),
            new(
                Guid.NewGuid(),
                "STU-20240002",
                "Naledi",
                "Dlamini",
                DateTime.UtcNow,
                new List<string> { "Netball", "Debate Society" },
                new List<string> { "Life Sciences", "Accounting", "isiZulu" }
            ),
            new(
                Guid.NewGuid(),
                "STU-20240003",
                "Sipho",
                "Nkosi",
                DateTime.UtcNow,
                new List<string> { "Soccer", "Drama" },
                new List<string> { "Software Engineering 201", "Discrete Mathematics", "Data Structures" }
            ),
            new(
                Guid.NewGuid(),
                "STU-20240004",
                "Lerato",
                "Van der Merwe",
                DateTime.UtcNow,
                new List<string> { "Athletics", "Art Club", "Choir" },
                new List<string> { "Database Systems 301", "Operating Systems", "Linear Algebra" }
            ),
            new(
                Guid.NewGuid(),
                "STU-20240005",
                "Amahle",
                "Botha",
                DateTime.UtcNow,
                new List<string> { "Swimming", "Science Olympiad" },
                new List<string> { "Artificial Intelligence 401", "Statistics II", "Research Methodology" }
            )
        };

        return students.ToDictionary(s => s.Id);
    }
}