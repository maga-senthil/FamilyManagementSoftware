using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class Chore
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Family")]
        public int FamilyId { get; set; }
        public Family Family { get; set; }
        public string Chores { get; set; }
        public bool Done { get; set; }
    }
}