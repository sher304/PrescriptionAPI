using Tutorial5.Data;
using Tutorial5.DTOs;

namespace Tutorial5.Services;

public interface DBPrescriptionProtocol
{
    public Task<List<Prescription>> getPrescriptions();
    public Task<PrescirptionPatientResponseDTO> addPrescription(PrescriptionPatientRequestDTO prescription);
}