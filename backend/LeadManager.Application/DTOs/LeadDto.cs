namespace LeadManager.Application.DTOs;

public class LeadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Suburb { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string Status { get; set; } = "invited";
    public DateTime DateCreated { get; set; }

    public static LeadDto FromEntity(LeadManager.Domain.Entities.Lead lead)
    {
        return new LeadDto
        {
            Id = lead.Id,
            FirstName = lead.FirstName,
            LastName = lead.LastName,
            Category = lead.Category,
            Suburb = lead.Suburb,
            Description = lead.Description,
            Price = lead.Price, 
            Email = lead.Email,
            Phone = lead.Phone,
            Status = lead.Status,
            DateCreated = lead.DateCreated
        };
    }
}
