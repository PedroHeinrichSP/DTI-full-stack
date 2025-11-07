using LeadManager.Application.Interfaces;
using LeadManager.Application.Services;
using LeadManager.Domain.Entities;
using Moq;

namespace LeadManager.Tests;

public class LeadServiceTests
{
    [Fact]
    public async Task AcceptLeadAsync_ShouldSendEmail_WhenLeadIsAccepted()
    {
        // Arrange
        var lead = new Lead { Id = 1, Price = 400m, Status = "invited" };

        var repoMock = new Mock<ILeadRepository>();
        repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(lead);

        var emailServiceMock = new Mock<IEmailService>();
        var service = new LeadService(repoMock.Object, emailServiceMock.Object);

        // Act
        var result = await service.AcceptLeadAsync(1);

        // Assert
        Assert.True(result);
        Assert.Equal("accepted", lead.Status);
        emailServiceMock.Verify(es => es.SendEmailAsync(
            It.IsAny<string>(),
            It.Is<string>(subject => subject.Contains("Lead Accepted")),
            It.IsAny<string>()),
            Times.Once);
    }

    [Fact]
    public async Task AcceptLeadAsync_ShouldReturnFalse_WhenLeadNotFound()
    {
        // Arrange
        var repoMock = new Mock<ILeadRepository>();
        repoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Lead?)null);

        var emailServiceMock = new Mock<IEmailService>();
        var service = new LeadService(repoMock.Object, emailServiceMock.Object);

        // Act
        var result = await service.AcceptLeadAsync(99);

        // Assert
        Assert.False(result);
        emailServiceMock.Verify(es => es.SendEmailAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()),
            Times.Never);
    }
}
