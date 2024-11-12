using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WarehouseApp
{
    public static class FileManager
    {
        public static void SavePalletsToFile(List<Pallet> pallets, string filePath)
        {
            try
            {
                var json = JsonConvert.SerializeObject(pallets, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Данные успешно сохранены в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        public static List<Pallet> LoadPalletsFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    var pallets = JsonConvert.DeserializeObject<List<Pallet>>(json);
                    Console.WriteLine("Данные успешно загружены из файла.");
                    return pallets;
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                    return new List<Pallet>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
                return new List<Pallet>();
            }
        }
    }
}