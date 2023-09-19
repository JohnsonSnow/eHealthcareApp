namespace eHealthcare.Entities
{
    public class ProductUnit
    {
        public int ProductUnitId { get; set; }
        public string UnitValue { get; set; } = string.Empty;
        public int ProductOfProductUnitId { get; private set; }
        public Product Product { get; private set; }
    }
}