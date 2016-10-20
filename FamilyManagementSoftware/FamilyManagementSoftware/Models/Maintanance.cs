using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class Maintanance
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int MaintenanceFrequency { get; set; }
        public float MaintenanceCost { get; set; }
    }
}