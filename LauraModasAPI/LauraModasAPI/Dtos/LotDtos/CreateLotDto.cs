namespace LauraModasAPI.Dtos.LotDtos
{
    public class CreateLotDto
    {
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }

        public DateOnly Date = DateOnly.FromDateTime(DateTime.Now);
    }
}
