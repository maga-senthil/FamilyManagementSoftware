using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class FamilyChoresViewModel
    {
        public int FamilyId { get; set; }
        public string Chores { get; set; }
        public string Name { get; set; }
        public IEnumerable<Chore> ChoreList { get; set; }
        public IEnumerable<Family> FamilyList { get; set; }
        public Chore ChoreView { get; set; }
    }
}