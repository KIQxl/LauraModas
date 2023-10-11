namespace LauraModasAPI.Dtos.BuyDtos
{
    public class GetBuyByDateRangeDto
    {
        public DateOnly InitialDate { get; set; }
        public DateOnly FinalDate { get; set;}
    }
}
