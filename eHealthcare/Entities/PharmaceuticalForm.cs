using System.Text.Json.Serialization;

namespace eHealthcare.Entities
{
    public class PharmaceuticalForm
    {
        public int PharmaceuticalFormId { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]

        public ICollection<Product>? Products { get; set; }


    }
}
