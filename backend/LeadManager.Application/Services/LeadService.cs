using LeadManager.Application.DTOs;
using LeadManager.Application.Interfaces;

namespace LeadManager.Application.Services;

public class LeadService : ILeadService
{
    private readonly ILeadRepository _repository;
    private readonly IEmailService _emailService;

    public LeadService(ILeadRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task<List<LeadDto>> GetLeadsAsync(string status)
    {
        var leads = await _repository.GetLeadsByStatusAsync(status);
        return leads.Select(LeadDto.FromEntity).ToList();
    }

    public async Task<bool> AcceptLeadAsync(int id, decimal? confirmedPrice = null)
    {
        var lead = await _repository.GetByIdAsync(id);
        if (lead is null) return false;

        if (lead.Price > 500 && confirmedPrice is null)
        {
            return false;
        }

        lead.Accept(confirmedPrice);
        await _repository.UpdateAsync(lead);

        // Send confirmation email
        var subject = $"Lead Accepted {lead.Id}";
        await _emailService.SendEmailAsync("vendas@test.com", subject, $"The lead has been accepted. {lead.Description}");
        return true;
    }

    public async Task<bool> DeclineLeadAsync(int id)
    {
        var lead = await _repository.GetByIdAsync(id);
        if (lead is null) return false;

        lead.Decline();
        await _repository.UpdateAsync(lead);
        return true;
    }
}
