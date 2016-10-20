using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class ChoreAllocationViewModel
    {
        [Display(Name = "Name")]
        public int FamilyId { get; set; }
        [Display(Name = "Chores")]
        public int ChoreId { get; set; }
        public string Chores { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public IEnumerable<Chore> choreList { get; set; }
        public IEnumerable<Family> familyList { get; set; }
        public Chore ChoreAllocationView { get; set; }

    }
}