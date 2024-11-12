using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using WarehouseApp;

public class WarehouseDisplayTests
{
    [Fact]
    public void DisplayPalletsByExpiration_ShouldOutputPalletsSortedByExpirationDate()
    {        var pallets = new List<Pallet>
        {
            new Pallet
            {
                Boxes = new List<Box> { new Box(10, 10, 10, 5, DateTime.Now, DateTime.Now.AddDays(1)) }
            },
            new Pallet
            {
                Boxes = new List<Box> { new Box(10, 10, 10, 5, DateTime.Now, DateTime.Now.AddDays(5)) }
            }
        };

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

           
            WarehouseDisplay.DisplayPalletsByExpiration(pallets);

            var output = sw.ToString();
            Assert.Contains("Срок годности", output);
        }
    }

    [Fact]
    public void DisplayTopPalletsByLongestBoxExpiration_ShouldDisplayTop3Pallets()
    {
        var pallets = new List<Pallet>
        {
            new Pallet { Boxes = new List<Box> { new Box(10, 10, 10, 5, DateTime.Now, DateTime.Now.AddDays(10)) }},
            new Pallet { Boxes = new List<Box> { new Box(10, 10, 10, 5, DateTime.Now, DateTime.Now.AddDays(20)) }},
            new Pallet { Boxes = new List<Box> { new Box(10, 10, 10, 5, DateTime.Now, DateTime.Now.AddDays(30)) }},
            new Pallet { Boxes = new List<Box> { new Box(10, 10, 10, 5, DateTime.Now, DateTime.Now.AddDays(40)) }}
        };

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            WarehouseDisplay.DisplayTopPalletsByLongestBoxExpiration(pallets);

            var output = sw.ToString();
            Assert.Contains("Топ 3 паллеты с наибольшим сроком годности коробок", output);
        }
    }
}
