using System.Text.Json.Serialization;

namespace eHealthcare.Entities
{
    public class Product
    {

        //public Product() { }
        //public Product(PharmaceuticalForm pharmaceuticalForm,
        //    ActiveIngredient activeIngredient,
        //    ProductUnit productUnit,
        //    ATCCode aTCCode,
        //    TherapeuticClass therapeuticClass)
        //{
        //    PharmaceuticalForm = pharmaceuticalForm;
        //    ActiveIngredient = activeIngredient;
        //    ProductUnit = productUnit;
        //    ATCCode = aTCCode;
        //    TherapeuticClass = therapeuticClass;
        //}

        public int Id { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public string Classifications { get; set; } = string.Empty;
        public string CompetentAuthorityStatus { get; set; } = string.Empty;
        public string InternalStatus { get; set; } = string.Empty;


        public int ActiveIngredientID { get; set; }
        //[JsonIgnore]
        public ActiveIngredient? ActiveIngredient { get; set; }

        public int PharmaceuticalFormID { get; set; }
        //[JsonIgnore]

        public PharmaceuticalForm? PharmaceuticalForm { get; set; }
        public int ProductUnitID { get; set; }
        //[JsonIgnore]

        public ProductUnit? ProductUnit { get; set; }

        public int ATCCodeID { get; set; }
        //[JsonIgnore]

        public ATCCode? ATCCode { get; set; }

        public int TherapeuticClassID { get; set; }
       // [JsonIgnore]

        public TherapeuticClass? TherapeuticClass { get; set; }
    }
}
