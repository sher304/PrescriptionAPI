using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial5.Data;

[Table("Prescription")]
public class Prescription
{
    [Key]
    private int idPrescription { get; set; }
    private DateTime Date { get; set; }
    private DateTime DueDate { get; set; }
    [ForeignKey(nameof(Patient))]
    private int IdPatient { get; set; }
    [ForeignKey(nameof(Doctor))]
    private int IdDoctor { get; set; }
    
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}