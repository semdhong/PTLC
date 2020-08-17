﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTLC.Data
{
    [Table("DeliveryMaster")]
    public partial class DeliveryMaster
    {
        public DeliveryMaster()
        {
            DeliveryItems = new HashSet<DeliveryItem>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string RefNo { get; set; }
        public Guid? MerchantId { get; set; }
        public Guid? RiderId { get; set; }
        [StringLength(128)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalDeliveryFee { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalPayable { get; set; }
        public int? TotalDelivered { get; set; }

        [ForeignKey(nameof(MerchantId))]
        [InverseProperty("DeliveryMasters")]
        public virtual Merchant Merchant { get; set; }
        [ForeignKey(nameof(RiderId))]
        [InverseProperty("DeliveryMasters")]
        public virtual Rider Rider { get; set; }
        [InverseProperty(nameof(DeliveryItem.DeliveryMaster))]
        public virtual ICollection<DeliveryItem> DeliveryItems { get; set; }
    }
}