using StudentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    public static List<Student> students = new List<Student>
    {
        new Student
        {
            Id = 1,
            Name = "Asilbek",
            Grade = "8",
        },
    };
    
    [HttpGet]
    public IActionResult GetStudent()
        => Ok(students);

    [HttpGet("{id}")]
    public IActionResult GetStudent([FromRoute]int id)
    {
        var student = students.FirstOrDefault(b => b.Id == id);
        if(student == default) return NotFound("Unaqa student topilmadi");
        return Ok(students);
    }

    [HttpPost]
    public IActionResult PostStudent([FromForm]Student student)
    {
        students.Add(student);
        return Created("api/student", student);
    }

    [HttpPut("{id}")]
    public IActionResult PutStudent([FromRoute]int id, [FromForm]Student student)
    {
        var old = students.FirstOrDefault(b => b.Id == id);
        if(old == default) return NotFound();
        old.Name = student.Name;
        old.Grade = student.Grade;
        return Accepted();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute]int id)
    {
        var student = students.FirstOrDefault(b => b.Id == id);
        if(student == default) return NotFound();
        students.Remove(student);
        return Accepted();
    }
}