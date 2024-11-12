using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp
{
    public static class WarehouseDisplay
    {
        public static void DisplayPalletsByExpiration(List<Pallet> pallets)
        {
            var groupedPallets = pallets
                .Where(p => p.ExpirationDate.HasValue)
                .OrderBy(p => p.ExpirationDate)
                .ThenBy(p => p.Weight)
                .GroupBy(p => p.ExpirationDate);

            Console.WriteLine("Паллеты, сгруппированные по сроку годности:");
            Console.WriteLine(new string('=', 50));

            foreach (var group in groupedPallets)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nСрок годности: {group.Key:dd.MM.yyyy}");
                Console.ResetColor();
                Console.WriteLine(new string('-', 50));

                foreach (var pallet in group)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("| Паллет ");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"ID: {pallet.Id,-2}");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | Коробок: ");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{pallet.Boxes.Count,-2}");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | Вес: ");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{pallet.Weight,6:F1} кг");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | Объем: ");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{pallet.Volume,8} куб.см |\n");

                    Console.ResetColor();
                }
                Console.WriteLine(new string('-', 50));
            }

            Console.WriteLine(new string('=', 50));
        }

        public static void DisplayTopPalletsByLongestBoxExpiration(List<Pallet> pallets)
        {
            var topPallets = pallets
                .Where(p => p.Boxes.Any())
                .OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate))
                .ThenBy(p => p.Volume)
                .Take(3);

            Console.WriteLine("\n3 паллеты с коробками с наибольшим сроком годности:");
            Console.WriteLine(new string('=', 50));

            foreach (var pallet in topPallets)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("| Паллет ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"ID: {pallet.Id,-2}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" | Коробок: ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{pallet.Boxes.Count,-2}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" | Объем: ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{pallet.Volume,8} куб.см");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" | Срок годности: ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{pallet.Boxes.Max(b => b.ExpirationDate)?.ToString("dd.MM.yyyy")} |\n");

                Console.ResetColor();
            }

            Console.WriteLine(new string('=', 50));
        }
    }
}
