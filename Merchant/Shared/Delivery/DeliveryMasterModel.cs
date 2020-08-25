using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Shared.Delivery
{
    public class DeliveryMasterModel
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public Guid? MerchantId { get; set; }
        public Guid? RiderId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalDeliveryFee { get; set; }
        public decimal? TotalPayable { get; set; }
        public int? TotalDelivered { get; set; }
        public string Origin { get; set; }
        public List<DeliverItemsModel> Items { get; set; }
    }
}
