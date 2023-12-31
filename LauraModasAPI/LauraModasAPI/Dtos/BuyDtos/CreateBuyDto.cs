﻿using LauraModasAPI.Models.Enums;

namespace LauraModasAPI.Dtos.BuyDtos
{
    public class CreateBuyDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public DateOnly DateOfPayment { get; set; }
        public int NumberOfInstallments { get; set; }

        public DateOnly Date = DateOnly.FromDateTime(DateTime.Now);
        public int CustomerModelId { get; set; }

    }
}
