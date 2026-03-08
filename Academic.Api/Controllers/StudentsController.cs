using System.Security.Cryptography;
using Academic.Api.Models;
using Academic.Api.Services.Students;
using Academic.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Academic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
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

        _studentService.CreateStudent(student);

        var response = new StudentResponse(
            student.Id,
            student.StudentNumber,
            student.FirstName,
            student.LastName,
            student.LastModifiedDateTime,
            student.ExtracurricularActivities,
            student.Courses
        );

        return CreatedAtAction(
            actionName: nameof(GetStudent),
            routeValues: new { id = student.Id },
            value : response
        );
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        Student student = _studentService.GetStudent(id);
        
        var response = new StudentResponse(
            student.Id,
            student.StudentNumber,
            student.FirstName,
            student.LastName,
            student.LastModifiedDateTime,
            student.ExtracurricularActivities,
            student.Courses
        );
        
        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest request, Guid id)
    {
        var student = _studentService.GetStudent(id);

        if (student == null)
        {
            return NotFound();
        }

        var req = new Student(
            id,
            request.StudentNumber,
            request.FirstName,
            request.LastName,
            DateTime.UtcNow,
            request.ExtracurricularActivities,
            request.Courses
        );

        _studentService.UpdateStudent(req, id);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var student = _studentService.GetStudent(id);

        if (student == null)
        {
            return NotFound();
        }
        
        _studentService.DeleteStudent(id);
        return NoContent();
    }
}