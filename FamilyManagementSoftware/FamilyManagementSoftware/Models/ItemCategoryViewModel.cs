using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class ItemCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable <ItemCategory> ItemCategoryList { get; set; }
        public ItemCategory ItemCategoryView { get; set; }
    }
}