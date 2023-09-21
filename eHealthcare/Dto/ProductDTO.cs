using eHealthcare.Entities;

namespace eHealthcare.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Classifications { get; set; } = string.Empty;
        public string CompetentAuthorityStatus { get; set; } = string.Empty;
        public string InternalStatus { get; set; } = string.Empty;
        public int ActiveIngredientID { get; set; }    
        public int PharmaceuticalFormID { get; set; }
        public int ProductUnitID { get; set; } 
        public int ATCCodeID { get; set; }
        public int TherapeuticClassID { get; set; }

    }
}
