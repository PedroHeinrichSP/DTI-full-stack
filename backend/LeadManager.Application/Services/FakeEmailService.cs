using LeadManager.Application.Interfaces;

namespace LeadManager.Application.Services;

public class FakeEmailService : IEmailService
{
    private readonly string _logPath;

    public FakeEmailService()
    {
        _logPath = Path.Combine(AppContext.BaseDirectory, "emails_sent.txt");
    }
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var logEntry = $"To: {to}\nSubject: {subject}\nBody: {body}\nSent At: {DateTime.UtcNow}\n\n";
        await File.AppendAllTextAsync(_logPath, logEntry + Environment.NewLine);
        Console.WriteLine("Fake email sent and logged.");
    }
}