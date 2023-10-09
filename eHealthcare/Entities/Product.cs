using System.Text.Json.Serialization;

namespace eHealthcare.Entities
{
    public class Product
    {


        public int Id { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public string Classifications { get; set; } = string.Empty;
        public string CompetentAuthorityStatus { get; set; } = string.Empty;
        public string InternalStatus { get; set; } = string.Empty;


        public int ActiveIngredientId { get; set; }
        public ActiveIngredient? ActiveIngredient { get; set; }

        public int PharmaceuticalFormId { get; set; }

        public PharmaceuticalForm? PharmaceuticalForm { get; set; }
        public int ProductUnitId { get; set; }

        public ProductUnit? ProductUnit { get; set; }

        public int ATCCodeId { get; set; }

        public ATCCode? ATCCode { get; set; }

        public int TherapeuticClassId { get; set; }
       // [JsonIgnore]

        public TherapeuticClass? TherapeuticClass { get; set; }
    }
}
