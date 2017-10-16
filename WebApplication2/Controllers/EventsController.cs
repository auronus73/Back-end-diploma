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
        public ActionResult List()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Events;
            return View(qwe);
        }


        // GET: Events/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit(Event even)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(even).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
