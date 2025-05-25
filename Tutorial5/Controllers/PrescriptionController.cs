using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tutorial5.Services;

namespace Tutorial5.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PrescriptionController : ControllerBase
{

    private readonly DBPrescriptionProtocol dbPrescriptionDelegate;

    public PrescriptionController(DBPrescriptionProtocol dbPrescriptionDelegate)
    {
        this.dbPrescriptionDelegate = dbPrescriptionDelegate;
    }

    [HttpGet]
    public async Task<IActionResult> getPrescriptions()
    {
        var prescriptions = await dbPrescriptionDelegate.getPrescriptions();
        return Ok(prescriptions);
    }
}