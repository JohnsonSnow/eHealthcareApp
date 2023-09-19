namespace eHealthcare.Entities
{
    public class Product
    {

        public Product() { }
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


        //public string ActiveIngredientID { get; set; } = string.Empty;
        //public string PharmaceuticalFormID { get; set; } = string.Empty;
        //public string ProductUnitID { get; set; } = string.Empty;
        //public string ATCCodeID { get; set; } = string.Empty;
        //public string TherapeuticClassID { get; set; } = string.Empty;
        public ActiveIngredient ActiveIngredient { get; set; }
        public PharmaceuticalForm PharmaceuticalForm { get; set; }
        public ProductUnit ProductUnit { get; set; }
        public ATCCode ATCCode { get; set; }
        public TherapeuticClass TherapeuticClass { get; set; }
    }
}
