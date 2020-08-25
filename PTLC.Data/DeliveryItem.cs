﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTLC.Data
{
    public partial class DeliveryItem
    {
        [Key]
        public int ItemsId { get; set; }
        public int? DeliveryMasterId { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        [StringLength(128)]
        public string Recipient { get; set; }
        [Column(TypeName = "text")]
        public string Address { get; set; }
        [Column(TypeName = "money")]
        public decimal? DeliveryFee { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalPayable { get; set; }
        public int? DeliveryStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ScheduleDate { get; set; }
        public double? Distance { get; set; }

        [ForeignKey(nameof(DeliveryMasterId))]
        [InverseProperty("DeliveryItems")]
        public virtual DeliveryMaster DeliveryMaster { get; set; }
        [ForeignKey(nameof(DeliveryStatus))]
        [InverseProperty("DeliveryItems")]
        public virtual DeliveryStatus DeliveryStatusNavigation { get; set; }
    }
}