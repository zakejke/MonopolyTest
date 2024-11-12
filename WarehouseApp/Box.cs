using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp
{
    public class Box : StorageItem
    {
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }

        public Box(int width, int height, int depth, double weight, DateTime? productionDate = null, DateTime? expirationDate = null)
        {
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate ?? productionDate?.AddDays(100);
        }
    }
}
