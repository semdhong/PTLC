using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModule.Shared.Maintenance
{
    public class RateMatrixModel
    {
       
        public int VehicleTypeId { get; set; }
        public decimal? BaseRate { get; set; }
        public decimal? KmRate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public VehicleTypeModel Vehicle { get; set; }
        public decimal? DropRate { get; set; }
        public decimal? HundredKm { get; set; }
        public decimal? HundredKmSucceed { get; set; }
        public decimal? ExcessHour { get; set; }
        public bool? Vatable { get; set; }

    }
}
