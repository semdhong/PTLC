using System;

namespace Merchant.Shared.Delivery
{
    public class DeliverItemsModel
    {
        public int ItemsId { get; set; }
        public int? DeliveryMasterId { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string Recipient { get; set; }
        public string Address { get; set; }
        public decimal? DeliveryFee { get; set; }
        public decimal? TotalPayable { get; set; }
        public int? DeliveryStatus { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public double? Distance { get; set; }
    }
}