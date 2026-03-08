using ErrorOr;

namespace Academic.Api.ServiceErrors;

public static class Errors
{
    public static class Student
    {
        public static Error NotFound => Error.NotFound("Student.NotFound", description: " Student not found");
    }
}