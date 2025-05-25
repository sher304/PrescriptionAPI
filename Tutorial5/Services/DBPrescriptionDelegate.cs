using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;

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

    public Task<Prescription> addPrescription(Prescription prescription)
    {
        if (prescription.DueDate < prescription.Date) throw new Exception("Due Date must be greater than or equal to Date"); 
        
        throw new NotImplementedException();
    }
}