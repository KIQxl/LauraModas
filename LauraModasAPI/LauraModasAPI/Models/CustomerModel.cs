namespace LauraModasAPI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public virtual List<BuyModel>? BuysModel { get; set; }
        public virtual InstallmentModel Installment { get; set; }
    }
}
