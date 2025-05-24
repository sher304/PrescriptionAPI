using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial5.Data;

[Table("Patient")]
public class Patient
{
    [Key]
    private int IdPatient { get; set; }
    [MaxLength(100)]
    private string FirstName { get; set; }
    [MaxLength(100)]
    private string LastName { get; set; }
    private DateTime BirthDate { get; set; }
}