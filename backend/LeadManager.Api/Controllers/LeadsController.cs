using LeadManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ILeadService _leadService;

    public LeadsController(ILeadService leadService)
    {
        _leadService = leadService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLeads([FromQuery] string status = "invited")
    {
        var leads = await _leadService.GetLeadsAsync(status);
        return Ok(leads);
    }

    [HttpPost("{id}/accept")]
    public async Task<IActionResult> AcceptLead(int id, [FromQuery] decimal? confirmedPrice = null)
    {
        var success = await _leadService.AcceptLeadAsync(id, confirmedPrice);
        if (!success)
        {
            return BadRequest(new
            {
                requiresConfirmation = true,
                message = "This lead requires a confirmed price to be accepted.",
                suggestedPrice = confirmedPrice ?? Math.Round((decimal)(await _leadService.GetLeadsAsync("invited"))
                    .First(l => l.Id == id).Price * 0.9m, 2)
            });
        }

        return Ok();
    }

    [HttpPost("{id}/decline")]
    public async Task<IActionResult> DeclineLead(int id)
    {
        var success = await _leadService.DeclineLeadAsync(id);
        return success ? Ok() : NotFound();
    }
}
