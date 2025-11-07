using LeadManager.Domain.Entities;

namespace LeadManager.Tests;

public class LeadTests
{
    [Fact]
    public void Accept_ShouldChangeStatusToAccepted()
    {
        // Arrange
        var lead = new Lead { Price = 400m };

        // Act
        lead.Accept();

        // Assert
        Assert.Equal("accepted", lead.Status);
    }

    [Fact]
    public void Accept_WithConfirmedPrice_ShouldUpdatePrice()
    {
        // Arrange
        var lead = new Lead { Price = 800m };

        // Act
        lead.Accept(720m);

        // Assert
        Assert.Equal("accepted", lead.Status);
        Assert.Equal(720m, lead.Price);
    }

    [Fact]
    public void Decline_ShouldChangeStatusToDeclined()
    {
        // Arrange
        var lead = new Lead { Status = "invited" };

        // Act
        lead.Decline();

        // Assert
        Assert.Equal("declined", lead.Status);
    }
}
