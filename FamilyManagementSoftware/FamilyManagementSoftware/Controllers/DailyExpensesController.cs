using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyManagementSoftware.Models;

namespace FamilyManagementSoftware.Controllers
{
    public class DailyExpensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DailyExpenses
        public ActionResult Index()
        {
            var dailyExpense = db.dailyExpense.Include(d => d.ItemCategorys);
            return View(dailyExpense.ToList());
        }

        // GET: DailyExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyExpense dailyExpense = db.dailyExpense.Find(id);
            if (dailyExpense == null)
            {
                return HttpNotFound();
            }
            return View(dailyExpense);
        }

        // GET: DailyExpenses/Create
        public ActionResult Create()
        {
            ViewBag.ItemCategoryId = new SelectList(db.itemCategory, "Id", "ItemName");
            return View();
        }

        // POST: DailyExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,ItemCategoryId,Amount")] DailyExpense dailyExpense)
        {
            if (ModelState.IsValid)
            {
                db.dailyExpense.Add(dailyExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCategoryId = new SelectList(db.itemCategory, "Id", "ItemName", dailyExpense.ItemCategoryId);
            return View(dailyExpense);
        }

        // GET: DailyExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyExpense dailyExpense = db.dailyExpense.Find(id);
            if (dailyExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCategoryId = new SelectList(db.itemCategory, "Id", "ItemName", dailyExpense.ItemCategoryId);
            return View(dailyExpense);
        }

        // POST: DailyExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,ItemCategoryId,Amount")] DailyExpense dailyExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCategoryId = new SelectList(db.itemCategory, "Id", "ItemName", dailyExpense.ItemCategoryId);
            return View(dailyExpense);
        }

        // GET: DailyExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyExpense dailyExpense = db.dailyExpense.Find(id);
            if (dailyExpense == null)
            {
                return HttpNotFound();
            }
            return View(dailyExpense);
        }

        // POST: DailyExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyExpense dailyExpense = db.dailyExpense.Find(id);
            db.dailyExpense.Remove(dailyExpense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult DailyExpenseView()
        {
            DailyExpenseViewModel model = new DailyExpenseViewModel();
            ViewBag.ItemCategoryId = new SelectList(db.itemCategory, "Id", "ItemName", model.ItemCategoryId);
            return View(model);
        }
        [HttpPost]
        public ActionResult DailyExpenseView(DailyExpenseViewModel model)
        {
            model.dailyexpensedetail = db.dailyExpense;
            //model.dailyexpensedetail.Reverse();
            model.budgetdetail = db.monthlyBudget;
            ItemCategory newItem = new ItemCategory();
            newItem = db.itemCategory.FirstOrDefault(x => x.Id == model.ItemCategoryId);
            var matchcCategory = newItem.CategoryId;
            MonthlyBudget newBudget = new MonthlyBudget();
            newBudget = db.monthlyBudget.FirstOrDefault(y => y.CategoryId == matchcCategory);
            if (model.Day.Month == newBudget.Month.Month)
            {
                newBudget.ActualAmount += model.Amount;
            }
            Category newCategory = new Category();
            var categoryNameList = db.category.Select(a => a).ToList();
            foreach (var item in categoryNameList)
            {
                var categoryName = db.category.FirstOrDefault(z => z.Id == matchcCategory);
                model.CategoryName = categoryName.CategoryName;
            }
            model.BudgetAmount = newBudget.BudgetAmount;
            model.ActualAmount = newBudget.ActualAmount;
            model.Month = newBudget.Month;

            var budgetall = db.monthlyBudget.Select(a => a.BudgetAmount).ToList();
            for (var i = 0; i < budgetall.Count; i++)
            {
                model.TotalBudget += budgetall[i];
            }

            var newExpense = new DailyExpense
            {
                Day = model.Day,
                ItemCategoryId = model.ItemCategoryId,
                Amount = model.Amount
            };
            db.dailyExpense.Add(newExpense);
            db.SaveChanges();

            var budgetall1 = db.monthlyBudget.Select(a => a.ActualAmount).ToList();
            for (var i = 0; i < budgetall.Count; i++)
            {
                model.TotalActual += budgetall1[i];
            }


            ModelState.Clear();
            ViewBag.ItemCategoryId = new SelectList(db.itemCategory, "Id", "ItemName", model.ItemCategoryId);
            return View(model);
        }


        public ActionResult testChart()
        {
            return View();
        }
    }
}
