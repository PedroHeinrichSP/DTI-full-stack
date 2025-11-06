using Microsoft.AspNetCore.Mvc;
using LeadManager.Domain.Entities;

namespace LeadManager.Api.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        // temporario: lista mockada de leads
        private static readonly List<Lead> _mockLeads = new()
        {
            new Lead { Id = 1, FirstName = "Bill", LastName = "Johnson", Category = "Painter", Suburb = "Yanderra 2574", Description = "Paint 2 windows", Price = 62, Status = "invited" },
            new Lead { Id = 2, FirstName = "Craig", LastName = "Smith", Category = "Interior Painter", Suburb = "Woolooware 2230", Description = "Walls 3 colours", Price = 49, Status = "invited" },
            new Lead { Id = 3, FirstName = "Laura", LastName = "Smith", Category = "Plumber", Suburb = "Sydney", Description = "Install water heater", Price = 620, DiscountedPrice = 558, Email = "laura.smith@example.com", Phone = "123-456-7890", Status = "accepted" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Lead>> GetLeads([FromQuery] string? status)
        {
            var leads = string.IsNullOrEmpty(status)
                ? _mockLeads
                : _mockLeads.Where(l => l.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

            return Ok(leads);
        }

        [HttpPost("{id}/accept")]
        public IActionResult AcceptLead(int id)
        {
            var lead = _mockLeads.FirstOrDefault(l => l.Id == id);
            if (lead is null) return NotFound();

            if (lead.Price > 500)
                lead.DiscountedPrice = lead.Price * 0.9m;

            lead.Status = "accepted";
            return Ok(lead);
        }

        [HttpPost("{id}/decline")]
        public IActionResult DeclineLead(int id)
        {
            var lead = _mockLeads.FirstOrDefault(l => l.Id == id);
            if (lead is null) return NotFound();

            lead.Status = "declined";
            return Ok(lead);
        }
    }
}
