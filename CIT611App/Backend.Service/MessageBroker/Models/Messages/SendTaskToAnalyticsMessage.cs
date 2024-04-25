using Backend.Service.MessageBroker.Models.Messages.Base;
using System.ComponentModel.DataAnnotations;
using System;
using Backend.Service.Data.Models.Order;

namespace Backend.Service.MessageBroker.Models.Messages
{
    public class SendTaskToAnalyticsMessage : BaseMessage
    {
        public string UID { get; set; }
        #region BaseModel
        
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; } = 1;
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        #endregion          
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
        public TaskStatusOption Status { get; set; }
        public string Code { get; set; }
        public int? PaymentMethodID { get; set; }
        public bool IsFastOrder { get; set; }
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
        public string? CustomerUID { get; set; } // CustomerID
        public string? StoreID { get; set; }
        public string? TeamUID { get; set; } //TeamID
        public string? StoreName { get; set; }
        public string? TeamName { get; set; }
        public string? DeliveryZoneName { get; set; }
        public string? BrandName { get; set; }
        public DateTime PlannedPickupTime { get; set; }
        public int AbuseType { get; set; }
        public DateTime? ArriveToPickupTime { get; set; }
        public DateTime? TripCloseTime { get; set; }
        public string? TripUID { get; set; } // TripID
        public string? NewTripNumber { get; set; } // TripReferenceNumber
        public string? ContactNumber { get; set; }
        public string? CustomerMobile { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
    }
}
