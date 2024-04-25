using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Service.Models.Shared;
using System.Collections.Generic;
using Backend.Service.Data.Models.Order;
using System;

namespace Backend.Service.Models
{
    public class Order : BaseModel
    {
        public DateTime? ShiftDate { get; set; }
        public string? OrderNumber { set; get; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public TaskRateOption Rate { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? ReadyTime { get; set; }
        public DateTime? AddedToTripTime { get; set; }
        public DateTime? InProgressTime { get; set; }
        public DateTime? TripCloseTime { get; set; }
        public TaskStatusOption Status { get; set; }
        public string Code { get; set; }
        public int? PaymentMethodID { get; set; }
        public bool IsFastOrder { get; set; }
        public bool IsPaused { get; set; }
        public bool IsAutoDispatched { get; set; }
        public bool IsTransite { get; set; }
        public bool IsRefund { get; set; } = false;
        public decimal Amount { get; set; }
        public decimal BalanceDue { get; set; }
        public string? RiderID { get; set; }
        public int? TripRate { get; set; }
        public DateTime? OnMyWayTime { get; set; }
        public DateTime? ArriveToCustomerTime { get; set; }
        public DateTime? OnMyWayToPickupTime { get; set; }
        public decimal? MoneyCollected { get; set; }
        public DateTime? PickingUpTime { get; set; }
        public bool? IsDeliverManually { get; set; }
        public DateTime? CancelTime { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? CustomerID { get; set; } // CustomerID
        public string? StoreID { get; set; }
        public string? TeamID { get; set; } //TeamID
        public string? StoreName { get; set; }
        public string? TeamName { get; set; }
        public string? DeliveryZoneName { get; set; }
        public string? BrandName { get; set; }
        public DateTime PlannedPickupTime { get; set; }
        public int AbuseType { get; set; }
        public DateTime? ArriveToPickupTime { get; set; }
        public string? TripID { get; set; } // TripID
        public string? TripReferenceNumber { get; set; } // TripReferenceNumber
        public string? ContactNumber { get; set; }
        public string? CustomerMobile { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
    }
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "Order");
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.Status).IsRequired();
        }
    }
}
