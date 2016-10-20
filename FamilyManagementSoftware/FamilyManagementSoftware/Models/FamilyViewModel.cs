using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class FamilyViewModel
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEnumerable<Family> FamilyMember { get; set; }
        public Family FamilyView { get; set; }


    }
}