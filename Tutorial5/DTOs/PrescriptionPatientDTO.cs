using Tutorial5.Data;

namespace Tutorial5.DTOs;

public class PrescriptionPatientDTO
{
    public Patient Patient { get; set; }
    public List<Medicament> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}