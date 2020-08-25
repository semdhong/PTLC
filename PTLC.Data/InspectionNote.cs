﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTLC.Data
{
    [Table("InspectionNote")]
    public partial class InspectionNote
    {
        [Key]
        public int InspectionNoteId { get; set; }
        public int Location { get; set; }
        [Required]
        [StringLength(100)]
        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public string VehicleLicenseNumber { get; set; }

        [ForeignKey(nameof(VehicleLicenseNumber))]
        [InverseProperty(nameof(Vehicle.InspectionNotes))]
        public virtual Vehicle VehicleLicenseNumberNavigation { get; set; }
    }
}