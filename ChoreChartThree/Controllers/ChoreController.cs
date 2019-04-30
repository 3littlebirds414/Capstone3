using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChoreChartThree.Models;

namespace ChoreChartThree.Controllers
{
    public class ChoreController : Controller
    {

        public ActionResult Details()
        {
            Chore chore = new Chore();
            {
              



            }
            return View();
            
        }

        // GET: Chore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chore/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chore/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chore/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
