namespace WarehouseApp
{
    public abstract class StorageItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public virtual double Weight { get; set; }
        public int Volume => Width * Height * Depth;
    }
}