﻿using LauraModasAPI.Models.Enums;
using System.Text.Json.Serialization;

namespace LauraModasAPI.Models
{
    public class BuyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public DateOnly DateOfPayment { get; set; }
        public int NumberOfInstallments { get; set; }
        public double InstallmentValue { get; set; }
        public double RemainingValue { get; set; }
        public DateOnly Date { get; set; }
        public int CustomerModelId { get; set; }

        public virtual CustomerModel CustomerModel { get; set; }
    }
}
