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
    public class ChoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chores
        public ActionResult Index()
        {
            var chores = db.Chores.Include(c => c.Family);
            return View(chores.ToList());
        }

        // GET: Chores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chore chore = db.Chores.Find(id);
            if (chore == null)
            {
                return HttpNotFound();
            }
            return View(chore);
        }

        // GET: Chores/Create
        public ActionResult Create()
        {
            ViewBag.FamilyId = new SelectList(db.family, "Id", "Name");
            return View();
        }

        // POST: Chores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FamilyId,Chores,Done")] Chore chore)
        {
            if (ModelState.IsValid)
            {
                db.Chores.Add(chore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(db.family, "Id", "Name", chore.FamilyId);
            return View(chore);
        }

        // GET: Chores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chore chore = db.Chores.Find(id);
            if (chore == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList(db.family, "Id", "Name", chore.FamilyId);
            return View(chore);
        }

        // POST: Chores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FamilyId,Chores,Done")] Chore chore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChoreView");

                //return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(db.family, "Id", "Name", chore.FamilyId);
            return View(chore);
        }

        // GET: Chores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chore chore = db.Chores.Find(id);
            if (chore == null)
            {
                return HttpNotFound();
            }
            return View(chore);
        }

        // POST: Chores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chore chore = db.Chores.Find(id);
            db.Chores.Remove(chore);
            db.SaveChanges();
            return RedirectToAction("ChoreView");
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ChoreView()
        {
          FamilyChoresViewModel  model = new FamilyChoresViewModel();
            model.ChoreList  = db.Chores;
            model.FamilyList = db.family;
            ViewBag.FamilyId = new SelectList(db.family, "Id", "Name", model.FamilyId);
            return View(model);
        }
        [HttpPost]
        public ActionResult ChoreView(FamilyChoresViewModel model)
        {
            model.ChoreList = db.Chores;
            model.FamilyList = db.family;

            var newChore = new Chore 
            {
                FamilyId =model.FamilyId ,
                Chores = model.Chores 
            };
            db.Chores.Add(newChore);
            db.SaveChanges();
            ViewBag.FamilyId = new SelectList(db.family, "Id", "Name", model.FamilyId);
            return View(model);
        }


        public ActionResult DailyChoresView()
        {
            KidsDailyChoresView model = new KidsDailyChoresView();
            return View(model);
        }
        [HttpPost]

        public ActionResult DailyChoresView(KidsDailyChoresView model,string Name)
        {
           // model.ChoreList = db.Chores;
            model.FamilyList = db.family;
            var name = db.family.Where(x => x.Name == Name).Single();
            var choreDetail = db.Chores.Where(y => y.FamilyId == name.Id).ToList();
            model.ChoreList = choreDetail;
            foreach(var item in choreDetail)
            {
                var chorList = db.Chores.FirstOrDefault(z => z.Chores == item.Chores);
                model.Chores = chorList.Chores;
            }
            // var nameId = db.Chores.FirstOrDefault(a => a.FamilyId == name.Id);
            foreach (var item in choreDetail)
            {
                item.Done = model.Done;
              //  db.Entry(model).State = EntityState.Modified;
               // db.SaveChanges();
                if (item.Done == true)
                {
                    name.Points += 1;
                }
            }


            return View(model);
        }
      
       // [HttpPost]
        public ActionResult AddingPoints(string Name)
        {
            Chore chore = new Chore();
            var name = db.family.Where(x => x.Name == Name).Single();
            var choreDetail = db.Chores.Where(y => y.FamilyId == name.Id).ToList();
            foreach (var item in choreDetail)
            {
                if (item.Done == true)
                {
                    name.Points += 1;
                }
            }

            return RedirectToAction("DailyChoresView");

        }

    }
}
