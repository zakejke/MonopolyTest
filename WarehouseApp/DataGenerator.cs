using System;
using System.Collections.Generic;

namespace WarehouseApp
{
    public static class DataGenerator
    {
        public static List<Pallet> GeneratePallets(int palletCount, int maxBoxesPerPallet)
        {
            var pallets = new List<Pallet>();
            var random = new Random();

            var expirationDates = new List<DateTime>
            {
                DateTime.Now.AddDays(30),
                DateTime.Now.AddDays(31),
                DateTime.Now.AddDays(35),
                DateTime.Now.AddDays(45),
                DateTime.Now.AddDays(55),
                DateTime.Now.AddDays(60)
            };

            for (int i = 0; i < palletCount; i++)
            {
                var pallet = new Pallet
                {
                    Width = random.Next(50, 100),
                    Height = random.Next(50, 100),
                    Depth = random.Next(50, 100)
                };

                int boxCount = random.Next(1, maxBoxesPerPallet);
                for (int j = 0; j < boxCount; j++)
                {
                    var productionDate = DateTime.Now.AddDays(-random.Next(0, 200));
                    var expirationDate = expirationDates[random.Next(expirationDates.Count)];
                    var box = new Box(
                        width: random.Next(10, pallet.Width),
                        height: random.Next(10, pallet.Height),
                        depth: random.Next(10, pallet.Depth),
                        weight: random.Next(1, 20),
                        productionDate: productionDate,
                        expirationDate: expirationDate
                    );
                    pallet.AddBox(box);
                }

                pallets.Add(pallet);
            }

            return pallets;
        }
    }
}