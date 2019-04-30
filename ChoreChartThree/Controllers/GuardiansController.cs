using ChoreChartThree.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoreChartThree.Controllers
{
    public class GuardiansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Guardians
        public ActionResult Index()
        {
            //use the current person logged in to retrieve their Dependents and return to view
            var userResult = User.Identity.GetUserId();
            var currentGuardian = db.Guardians.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            var dependentList = db.Dependents.Where(x => currentGuardian.GuardianId == x.GuardianId).ToList();
            return View(dependentList);
        }

        // GET: Guardians/Details/5
        public ActionResult Details()
        {
            var currentPerson = User.Identity.GetUserId();
            var currentUser = db.Guardians.Where(x => currentPerson == x.ApplicationId).FirstOrDefault();
            return View(currentUser);
        }

        // GET: Guardians/Create
        public ActionResult Create()
        {
            Guardian guardian = new Guardian();
            return View(guardian);
        }

        // POST: Guardians/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GuardianName")] Guardian guardian)
        {
            guardian.ApplicationId = User.Identity.GetUserId();
            if(ModelState.IsValid)
            {
                db.Guardians.Add(guardian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(guardian);
        }

        // GET: Guardians/Edit/5
        public ActionResult Edit(int? id)
        {
            var guardianIs = db.Guardians.Where(w => w.GuardianId == id).FirstOrDefault();
            return View(guardianIs);
        }

        // POST: Guardians/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id, GuardianName")] Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guardian).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(guardian);
        }

        // GET: Guardians/Delete/5
        public ActionResult Delete(int id)
        {
            var guardianIs = db.Guardians.Where(w => w.GuardianId == id).FirstOrDefault();
            return View(guardianIs);
        }

        // POST: Guardians/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var DeleteGuardian = db.Guardians.Where(w => w.GuardianId == id).FirstOrDefault();
                db.Guardians.Remove(DeleteGuardian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
