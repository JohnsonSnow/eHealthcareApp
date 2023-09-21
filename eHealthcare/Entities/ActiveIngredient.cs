using System.Text.Json.Serialization;

namespace eHealthcare.Entities
{
    public class ActiveIngredient
    {
        public int ActiveIngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]

        public ICollection<Product>? Products { get; set; }

    }
}
