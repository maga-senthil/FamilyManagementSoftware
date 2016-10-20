using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class Family
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }


    }
}