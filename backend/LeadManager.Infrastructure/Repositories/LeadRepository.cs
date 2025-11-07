using LeadManager.Domain.Entities;
using LeadManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LeadManager.Application.Interfaces;

namespace LeadManager.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly AppDbContext _context;

        public LeadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lead>> GetLeadsByStatusAsync(string status)
        {
            return await _context.Leads
                .Where(lead => lead.Status == status)
                .ToListAsync();
        }

        public async Task<Lead?> GetByIdAsync(int id)
        {
            return await _context.Leads.FindAsync(id);
        }

        public async Task UpdateAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }
    }
}   