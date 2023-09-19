namespace eHealthcare.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TranType { get; set; } = string.Empty;
    }
}
