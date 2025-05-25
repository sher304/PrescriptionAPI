using Tutorial5.Data;
using Tutorial5.Services.Patient;

namespace Tutorial5.Services;

public class DBPatientDelegate : DBPatientProtocol
{

    private readonly DatabaseContext _dbcontext;

    public DBPatientDelegate(DatabaseContext dbcontext)
    {
        this._dbcontext = dbcontext;
    }

    public async Task<bool> addPatient(Data.Patient patient)
    {
        _dbcontext.Add<Data.Patient>(patient);
        var result = await _dbcontext.SaveChangesAsync();
        return result > 0;
    }
}