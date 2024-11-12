using Xunit;
using WarehouseApp;

public class PalletTests
{
    [Fact]
    public void AddBox_ShouldAddBox_WhenSizeIsValid()
    {
        var pallet = new Pallet { Width = 100, Height = 100, Depth = 100 };
        var box = new Box(width: 50, height: 50, depth: 50, weight: 10);

        pallet.AddBox(box);

        Assert.Contains(box, pallet.Boxes);
    }

    [Fact]
    public void AddBox_ShouldNotAddBox_WhenSizeExceedsPallet()
    {
        var pallet = new Pallet { Width = 50, Height = 50, Depth = 50 };
        var box = new Box(width: 100, height: 100, depth: 100, weight: 10);

        pallet.AddBox(box);

        Assert.DoesNotContain(box, pallet.Boxes);
    }
}
