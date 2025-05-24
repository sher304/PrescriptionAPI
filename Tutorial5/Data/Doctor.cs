using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial5.Data;

[Table("Doctor")]
public class Doctor
{
    [Key]
    private int idDoctor { get; set; }
    [MaxLength(100)]
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Email { get; set; }
}