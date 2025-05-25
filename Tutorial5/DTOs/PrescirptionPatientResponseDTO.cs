public class PrescirptionPatientResponseDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public List<PrescriptionDTO> Prescriptions { get; set; }
}

public class PrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public DoctorDTO Doctor { get; set; } 
    public List<MedicamentDTO> Medicaments { get; set; }
}

public class DoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}

public class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}