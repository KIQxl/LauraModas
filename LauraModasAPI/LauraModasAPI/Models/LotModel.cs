namespace LauraModasAPI.Models
{
    public class LotModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public double AmountValue { get; set; }
        public DateOnly Date { get; set; }
    }
}
