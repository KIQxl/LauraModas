namespace LauraModasAPI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public double Amount { get; set; }
        public virtual List<BuyModel>? BuysModel { get; set; }

    }
}
