using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;

namespace Tutorial5.Services;

public class DBPrescriptionDelegate : DBPrescriptionProtocol
{

    private readonly DatabaseContext _dbContext;
    
    public DBPrescriptionDelegate(DatabaseContext _dbcontext)
    {
        this._dbContext = _dbcontext;    
    }

    public  async Task<List<Prescription>> getPrescriptions()
    {
        var prescriptions = await _dbContext.Prescriptions.ToListAsync();
        return prescriptions;
    }

  public async Task<PrescirptionPatientResponseDTO> addPrescription(PrescriptionPatientRequestDTO prescription)
{
    if (prescription.DueDate < prescription.Date)
        throw new Exception("Due Date must be greater than or equal to Date");

    // 2. Find or create patient
    var patient = await _dbContext.Patients
        .FirstOrDefaultAsync(p => p.IdPatient == prescription.Patient.IdPatient);

    if (patient == null)
    {
        patient = new Data.Patient
        {
            FirstName = prescription.Patient.FirstName,
            LastName = prescription.Patient.LastName,
            BirthDate = prescription.Patient.BirthDate
        };

        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync();
    }

    // 3. Get doctor (must exist)
    var doctor = await _dbContext.Doctors.FindAsync(prescription.IdDoctor);
    if (doctor == null)
        throw new Exception("Doctor not found");

    // 4. Validate medication count
    if (prescription.Medicaments.Count > 10)
        throw new Exception("Maximum of 10 medications allowed");

    // 5. Validate all medications exist
    var medicamentIds = prescription.Medicaments.Select(m => m.IdMedicament).ToList();
    var existingMedicaments = await _dbContext.Medicaments
        .Where(m => medicamentIds.Contains(m.IdMedicament))
        .ToListAsync();

    if (existingMedicaments.Count != medicamentIds.Count)
        throw new Exception("One or more medications not found");

    // 6. Create new prescription entity
    var newPrescription = new Prescription
    {
        Date = prescription.Date,
        DueDate = prescription.DueDate,
        IdPatient = patient.IdPatient,
        IdDoctor = doctor.IdDoctor,
        PrescriptionMedicaments = prescription.Medicaments.Select(m => new Prescription_Medicament
        {
            IdMedicament = m.IdMedicament,
            Dose = m.Dose,
            Details = m.Description,
        }).ToList()
    };

    _dbContext.Prescriptions.Add(newPrescription);
    await _dbContext.SaveChangesAsync();

    // 7. Reload patient with related data
    var updatedPatient = await _dbContext.Patients
        .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
        .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
        .FirstOrDefaultAsync(p => p.IdPatient == patient.IdPatient);

    // 8. Map to response DTO
    var dto = new PrescirptionPatientResponseDTO
    {
        IdPatient = updatedPatient.IdPatient,
        FirstName = updatedPatient.FirstName,
        Prescriptions = updatedPatient.Prescriptions.Select(p => new PrescriptionDTO
        {
            IdPrescription = p.IdPrescription,
            Date = p.Date,
            DueDate = p.DueDate,
            Doctor = new DoctorDTO
            {
                IdDoctor = p.Doctor.IdDoctor,
                FirstName = p.Doctor.FirstName
            },
            Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDTO
            {
                IdMedicament = pm.Medicament.IdMedicament,
                Name = pm.Medicament.Name,
                Dose = pm.Dose,
                Description = pm.Medicament.Description
            }).ToList()
        }).OrderBy(p => p.DueDate).ToList()
    };

    return dto;
    }
}