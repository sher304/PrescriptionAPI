using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Tutorial5.Data;

[Table("Prescription_Medicament")]
public class Prescription_Medicament
{
    [ForeignKey(nameof(Medicament))]
    private int IdMedicament { get; set; }
    [ForeignKey(nameof(Doctor))]
    private int IdPrescription { get; set; }
    private int? Dose { get; set; }
    [MaxLength(100)]
    private string Details { get; set; }
    private  Medicament Medicament { get; set; }
    private  Doctor Doctor { get; set; }
}