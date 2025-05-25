using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tutorial5.Data;
using Tutorial5.DTOs;
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

    public async Task<IActionResult> addPrescription([FromBody] PrescriptionPatientRequestDTO prescriptionPatientRequestDto) 
    {
        try
        {
            var result = await dbPrescriptionDelegate.addPrescription(prescriptionPatientRequestDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}