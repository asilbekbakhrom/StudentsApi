using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models;
public class Student
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(2)]
    public string? Grade { get; set; }
    
}