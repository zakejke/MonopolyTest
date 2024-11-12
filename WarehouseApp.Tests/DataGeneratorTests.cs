using Xunit;
using System.Collections.Generic;
using WarehouseApp;

public class DataGeneratorTests
{
    [Fact]
    public void GeneratePallets_ShouldGenerateCorrectNumberOfPallets()
    {
        var pallets = DataGenerator.GeneratePallets(5, 10);

        Assert.Equal(5, pallets.Count);
    }

    [Fact]
    public void GeneratePallets_ShouldGeneratePalletsWithBoxes()
    {
        var pallets = DataGenerator.GeneratePallets(3, 5);

        Assert.All(pallets, pallet => Assert.True(pallet.Boxes.Count > 0));
    }
}
