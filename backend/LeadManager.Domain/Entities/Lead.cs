namespace LeadManager.Domain.Entities
{
    public class Lead
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
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public void Accept(decimal? confirmedPrice = null)
        {
            if (confirmedPrice.HasValue)
            {
                Price = confirmedPrice.Value;
            }
            
            Status = "accepted";
        }

        public void Decline()
        {
            Status = "declined";
        }
    }
}
