namespace Tutorial5.Services.Patient;

public interface DBPatientProtocol
{
    Task<bool> addPatient(Data.Patient patient);
}