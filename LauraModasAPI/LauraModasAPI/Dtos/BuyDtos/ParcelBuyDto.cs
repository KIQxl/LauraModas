namespace LauraModasAPI.Dtos.BuyDtos
{
    public class ParcelBuyDto
    {
        public int Id { get; set; }
        public int NumberOfInstallments { get; set; }
        public DateOnly DateOfPayment { get; set; }
    }
}
