using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class MonthlyBudgetViewModel
    {
        public int CategoryId { get; set; }
        public Category Categorys { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Month { get; set; }
        public float BudgetAmount { get; set; }
        public float ActualAmount { get; set; }
        public IEnumerable <Category> CategoryList { get; set; }
        public IEnumerable <MonthlyBudget> BudgetList { get; set; }
        public MonthlyBudget MonthlyBudgetView { get; set; }
    }
}