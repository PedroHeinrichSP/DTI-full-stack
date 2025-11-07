using LeadManager.Application.Services;

namespace LeadManager.Tests;

public class FakeEmailServiceTests
{
    [Fact]
    public async Task SendEmailAsync_ShouldWriteToFile()
    {
        var service = new FakeEmailService();
        await service.SendEmailAsync("vendas@test.com", "Teste", "Corpo do e-mail");

        var path = Path.Combine(AppContext.BaseDirectory, "emails_sent.txt");
        Assert.True(File.Exists(path));

        var content = await File.ReadAllTextAsync(path);
        Assert.Contains("vendas@test.com", content);
        Assert.Contains("Teste", content);
    }
}
