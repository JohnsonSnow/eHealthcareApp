using System.Text.Json.Serialization;

namespace eHealthcare.Entities
{
    public class ProductUnit
    {
        public int ProductUnitId { get; set; }
        public string UnitValue { get; set; } = string.Empty;
        [JsonIgnore]

        public ICollection<Product>? Products { get; set; }


    }
}