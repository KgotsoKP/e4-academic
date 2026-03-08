namespace Academic.Contracts;

public record StudentResponse(
    Guid Id,
    string StudentNumber,
    string FirstName,
    string LastName,
    DateTime LastModifiedDateTime,
    List<string> ExtracurricularActivities,
    List<string> Courses
);