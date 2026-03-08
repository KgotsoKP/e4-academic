using System.Security.Cryptography;
using Academic.Api.Models;
using Academic.Api.Services.Students;
using Academic.Contracts;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace Academic.Api.Controllers;

public class StudentsController : ApiController
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
    {
        var student = new Student(
            Guid.NewGuid(),
            RandomNumberGenerator.GetInt32(1000, 10000).ToString(),
            request.FirstName,
            request.LastName,
            DateTime.UtcNow,
            request.ExtracurricularActivities,
            request.Courses
        );

        ErrorOr<Created> createStudentResult =  _studentService.CreateStudent(student);
        
        if (createStudentResult.IsError)
        {
            return Problem(createStudentResult.Errors);
        }
        
        return CreatedAtAction(
            actionName: nameof(GetStudent),
            routeValues: new { id = student.Id },
            value : MapStudentResponse(student)
        );
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        ErrorOr<Student> getStudentResult = _studentService.GetStudent(id);
        
        return getStudentResult.Match(
            student => Ok(MapStudentResponse(student)),
            errors => Problem(errors));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest request, Guid id)
    {
        var req = new Student(
            id,
            request.StudentNumber,
            request.FirstName,
            request.LastName,
            DateTime.UtcNow,
            request.ExtracurricularActivities,
            request.Courses
        );
        
        ErrorOr<Updated> updateStudentResult = _studentService.UpdateStudent(req, id);
        
        return updateStudentResult.Match(
            updated =>  NoContent(),
            errors => Problem(errors));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        
        ErrorOr<Deleted> deleteStudentResult = _studentService.DeleteStudent(id);
        
        return deleteStudentResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
    
    private static StudentResponse MapStudentResponse(Student student)
    {
        return new StudentResponse(
            student.Id,
            student.StudentNumber,
            student.FirstName,
            student.LastName,
            student.LastModifiedDateTime,
            student.ExtracurricularActivities,
            student.Courses
        );
    }
}