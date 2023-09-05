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
        public PurchaseEnum? Status { get; set; }

        public DateTime Date { get; set; }
        public int CustomerModelId { get; set; }

        [JsonIgnore]
        public virtual CustomerModel CustomerModel { get; set; }

        //public BuyModel(string name, double value, string description, int customerId, CustomerModel customer)
        //{
        //    this.Name = name;
        //    this.Value = value;
        //    this.Description = description;
        //    this.CustomerModelId = customerId;
        //    this.Date = DateTime.Now;
        //    this.Status = PurchaseEnum.NaoPago;
        //    CustomerModel = customer;
        //}
    }
}
