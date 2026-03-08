namespace Academic.Contracts;

public record UpdateStudentRequest(
    string StudentNumber,
    string FirstName,
    string LastName,
    DateTime LastModifiedDateTime,
    List<string> ExtracurricularActivities,
    List<string> Courses
    );