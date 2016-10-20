using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagementSoftware.Models
{
    public class DailyExpenseViewModel
    {
        public string ItemName { get; set; }
        public DateTime Month { get; set; }
        public float BudgetAmount { get; set; }
        public float ActualAmount { get; set; }
        public string CategoryName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Day { get; set; }
        public int ItemCategoryId { get; set; }
        public float Amount { get; set; }
        public float Difference { get; set; }
        [Display(Name = "Total")]
        public float TotalBudget { get; set; }
        public float TotalActual { get; set; }
        public IEnumerable<MonthlyBudget> budgetdetail { get; set; }
        public IEnumerable<DailyExpense> dailyexpensedetail { get; set; }
        public DailyExpense DailyExpenseView { get; set; }
    }
}