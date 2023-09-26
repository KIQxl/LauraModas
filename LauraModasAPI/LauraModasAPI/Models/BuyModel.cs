using LauraModasAPI.Models.Enums;
using System.Text.Json.Serialization;

namespace LauraModasAPI.Models
{
    public class BuyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }

        public DateTime Date { get; set; }
        public int CustomerModelId { get; set; }

        public virtual CustomerModel CustomerModel { get; set; }
    }
}
