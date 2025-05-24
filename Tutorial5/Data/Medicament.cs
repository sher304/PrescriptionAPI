using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial5.Data;

[Table("Medicament")]
public class Medicament
{
    [Key]
    private int idMedicament { get; set; }
    [MaxLength(100)]
    private string Name { get; set; }
    [MaxLength(100)]
    private string Description { get; set; }
    [MaxLength(100)]
    private string Type { get; set; }
}