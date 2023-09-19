namespace eHealthcare.Entities
{
    public class TherapeuticClass
    {
        public int TherapeuticClassId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProductOfTherapeuticClassId { get; private set; }
        public Product Product { get; private set; }
    }
}
