using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp
{
    public class Pallet : StorageItem
    {
        private static int _nextId = 1;
        public Guid Id { get; private set; }
        public int DisplayId { get; private set; }

        public List<Box> Boxes { get; set; } = new List<Box>();
        public DateTime? ExpirationDate => Boxes.Min(box => box.ExpirationDate);
        public new double Weight => Boxes.Sum(box => box.Weight) + 30;
        public new int Volume => base.Volume + Boxes.Sum(box => box.Volume);

        public Pallet()
        {
            Id = Guid.NewGuid();
            DisplayId = _nextId++;
            if (_nextId > 10)
                _nextId = 1;
        }

        public void AddBox(Box box)
        {
            if (box.Width <= Width && box.Depth <= Depth)
                Boxes.Add(box);
            else
                Console.WriteLine("Превышает размер поддона");
        }
    }
}