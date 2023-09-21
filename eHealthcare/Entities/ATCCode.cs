
using System.Text.Json.Serialization;

namespace eHealthcare.Entities
{
    public class ATCCode
    {
        public int ATCCodeId { get; set; }
        public string Code { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }

    }
}
