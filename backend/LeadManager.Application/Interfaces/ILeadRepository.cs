using LeadManager.Domain.Entities;

namespace LeadManager.Application.Interfaces;

public interface ILeadRepository
{
    Task<List<Lead>> GetLeadsByStatusAsync(string status);
    Task<Lead?> GetByIdAsync(int id);
    Task UpdateAsync(Lead lead);
}
