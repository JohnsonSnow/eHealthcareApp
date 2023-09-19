namespace eHealthcare.Entities
{
    public class ATCCode
    {
        public int ATCCodeId { get; set; }
        public string Code { get; set; } = string.Empty;
        public int ProductOfATCCodeId { get; private set; }
        public Product Product { get; private set; }
    }
}
