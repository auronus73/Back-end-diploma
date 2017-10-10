using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Events()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Events;
            return View(qwe);
        }

        // GET: Events/Create
        public ActionResult CreateEvent()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        public ActionResult CreateEvent(Event even)
        {
            var asd = new diplomaEntities();
            try
            {
                // TODO: Add insert logic here

                asd.Events.Add(even);
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("/Events");
            }
            catch
            {
                return View(asd.Events);
            }
        }

        // GET: Events/Edit/5
        public ActionResult EditEvent(int id)
        {
            var asd = new diplomaEntities();
            Event even = asd.Events.Find(id);
            if (even != null)
            {
                return View(even);
            }
            return HttpNotFound();
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult EditEvent(Event even)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(even).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Events");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult DeleteEvent(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult DeleteEvent(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Events");
            }
            catch
            {
                return View();
            }
        }
    }
}
