using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Tutorial5.Data;

[Table("Prescription_Medicament")]
public class Prescription_Medicament
{
    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
    public  Medicament Medicament { get; set; }
}