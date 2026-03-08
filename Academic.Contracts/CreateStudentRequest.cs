namespace Academic.Contracts;

public record CreateStudentRequest(
    string FirstName,
    string LastName,
    List<string> ExtracurricularActivities,
    List<string> Courses
    );