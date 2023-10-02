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


        public int ActiveIngredientID { get; set; }
        public ActiveIngredient? ActiveIngredient { get; set; }

        public int PharmaceuticalFormID { get; set; }

        public PharmaceuticalForm? PharmaceuticalForm { get; set; }
        public int ProductUnitID { get; set; }

        public ProductUnit? ProductUnit { get; set; }

        public int ATCCodeID { get; set; }

        public ATCCode? ATCCode { get; set; }

        public int TherapeuticClassID { get; set; }
       // [JsonIgnore]

        public TherapeuticClass? TherapeuticClass { get; set; }
    }
}
