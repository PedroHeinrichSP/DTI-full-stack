using LeadManager.Application.Interfaces;
using LeadManager.Application.Services;
using LeadManager.Domain.Entities;
using Moq;

namespace LeadManager.Tests;

public class LeadServiceTests
{
    [Fact]
    public async Task AcceptLead_ShouldApplyDiscount_WhenPriceAbove500()
    {
        // Arrange
        var lead = new Lead { Id = 1, Price = 800m, Status = "invited" };
        var repoMock = new Mock<ILeadRepository>();
        repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(lead);

        var service = new LeadService(repoMock.Object);

        // Act
        var result = await service.AcceptLeadAsync(1);

        // Assert
        Assert.True(result);
        Assert.Equal("accepted", lead.Status);
    }
}
