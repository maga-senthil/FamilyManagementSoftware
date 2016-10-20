using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable <Category> CategoryList { get; set; }
        public Category CategoryView { get; set; }
    }
}