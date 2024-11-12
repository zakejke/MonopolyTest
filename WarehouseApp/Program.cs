using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp
{
    class Program
    {
        static void Main()
        {
            var pallets = DataGenerator.GeneratePallets(5, 10);

            WarehouseDisplay.DisplayPalletsByExpiration(pallets);

            WarehouseDisplay.DisplayTopPalletsByLongestBoxExpiration(pallets);

            AddBoxToPallet(pallets);

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void AddBoxToPallet(List<Pallet> pallets)
        {
            Console.WriteLine("Доступные паллеты (ID):");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"ID: {pallet.Id}");
            }

            Console.Write("Введите ID паллета для добавления коробки (GUID): ");
            var palletIdInput = Console.ReadLine();

            if (Guid.TryParse(palletIdInput, out Guid palletId))
            {
                var pallet = pallets.FirstOrDefault(p => p.Id == palletId);
                if (pallet == null)
                {
                    Console.WriteLine("Паллет с таким ID не найден.");
                    return;
                }

                // Ввод данных для коробки
                Console.Write("Введите ширину коробки (см): ");
                int width = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите глубину коробки (см): ");
                int depth = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите высоту коробки (см): ");
                int height = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите вес коробки (кг): ");
                double weight = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите срок годности коробки (дд.мм.гггг): ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите дату производства коробки (дд.мм.гггг): ");
                DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

                Box newBox = new Box(width, depth, height, weight, expirationDate, manufactureDate);
                pallet.AddBox(newBox);
                Console.WriteLine("Коробка добавлена к паллету.");
            }
            else
            {
                Console.WriteLine("Некорректный формат GUID.");
            }
        }
    }
}