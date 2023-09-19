namespace eHealthcare.Entities
{
    public class ActiveIngredient
    {
        public int ActiveIngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProductOfActiveIngredientId { get; private set; }
        public Product Product { get; private set; }

    }
}
