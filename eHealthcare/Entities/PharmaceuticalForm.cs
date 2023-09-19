namespace eHealthcare.Entities
{
    public class PharmaceuticalForm
    {
        public int PharmaceuticalFormId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProductOfPharmaceuticalFormId { get; private set; }
        public Product Product { get; private set; }
    }
}
