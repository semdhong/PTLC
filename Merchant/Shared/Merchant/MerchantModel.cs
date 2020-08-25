using Merchant.Shared.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Shared.Merchant
{
    public class MerchantModel
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string BusinessName { get; set; }
        public int? BusinessClassId { get; set; }
        public string ContactPerson { get; set; }
        public string TelNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string QrCode { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public BusinessClassModel BusinessClass { get; set; }
        public string UserId { get; set; }
    }
}
