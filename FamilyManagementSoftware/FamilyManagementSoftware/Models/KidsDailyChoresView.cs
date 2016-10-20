using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class KidsDailyChoresView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chores { get; set; }
        public bool Done { get; set; }
        public int PointsEarned { get; set; }
        public IEnumerable<Chore> ChoreList { get; set; }
        public IEnumerable<Family> FamilyList { get; set; }
        public Chore DailyChoresView { get; set; }


    }
}