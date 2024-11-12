using Xunit;
using System;
using WarehouseApp;

public class BoxTests
{
    [Fact]
    public void Constructor_ShouldSetExpirationDate_WhenProvided()
    {
        var productionDate = DateTime.Now;
        var expirationDate = productionDate.AddDays(50);

        var box = new Box(10, 10, 10, 5, productionDate, expirationDate);

        Assert.Equal(expirationDate, box.ExpirationDate);
    }

    [Fact]
    public void Constructor_ShouldCalculateExpirationDate_WhenNotProvided()
    {
        var productionDate = DateTime.Now;
        var box = new Box(10, 10, 10, 5, productionDate);

        Assert.Equal(productionDate.AddDays(100), box.ExpirationDate);
    }

    [Fact]
    public void Volume_ShouldCalculateVolumeCorrectly()
    {
        var box = new Box(2, 3, 4, 5);

        Assert.Equal(24, box.Volume);
    }
}
