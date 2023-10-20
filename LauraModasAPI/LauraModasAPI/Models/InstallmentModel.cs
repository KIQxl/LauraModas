namespace LauraModasAPI.Models
{
    public class InstallmentModel
    {  
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfInstallments { get; set; }
        public double TotalValue { get; set; } 
        public double InstallmentValue { get; set; }
        public double RemainingValue { get; set; }
        public DateOnly DateOfPayment { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}
