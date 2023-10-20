namespace LauraModasAPI.Models
{
    public class BuyLogModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public double PaymentValue { get; set; }
        public DateOnly DateOfPayment { get; set; }
        public string NameOfProduct { get; set; }
    }
}
