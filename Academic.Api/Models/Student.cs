namespace Academic.Api.Models;

// use a constructor to set the values.
public class Student
{
    public Student(Guid id, string studentNumber, string firstName, string lastName, DateTime lastModifiedDateTime, List<string> extracurricularActivities, List<string> courses)
    {
        Id = id;
        StudentNumber = studentNumber;
        FirstName = firstName;
        LastName = lastName;
        LastModifiedDateTime = lastModifiedDateTime;
        ExtracurricularActivities = extracurricularActivities;
        Courses = courses;
    }

    public Guid Id { get; }
    public string StudentNumber { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime LastModifiedDateTime { get;}
    public List<string> ExtracurricularActivities { get; }
    public List<string> Courses { get;}
}