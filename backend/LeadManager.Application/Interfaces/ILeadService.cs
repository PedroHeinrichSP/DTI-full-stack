using LeadManager.Application.DTOs;

namespace LeadManager.Application.Interfaces;

public interface ILeadService
{
    Task<List<LeadDto>> GetLeadsAsync(string status);
    Task<bool> AcceptLeadAsync(int id, decimal? confirmedPrice);
    Task<bool> DeclineLeadAsync(int id);
}
