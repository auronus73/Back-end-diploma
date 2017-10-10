using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ListsController : Controller
    {
        // GET: Lists
        public ActionResult Lists()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Lists;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }

        // GET: Lists/Create
        public ActionResult CreateList()
        {
            return View();
        }

        // POST: Lists/Create
        [HttpPost]
        public ActionResult CreateList(List list)
        {
            var asd = new diplomaEntities();
            try
            {
                // TODO: Add insert logic here
                asd.Lists.Add(list);
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Lists/Lists");
            }
            catch
            {
                return View(asd.Lists);
            }
        }

        // GET: Lists/Edit/5
        public ActionResult EditList(int id)
        {
            var asd = new diplomaEntities();
            List list = asd.Lists.Find(id);
            if (list != null)
            {
                return View(list);
            }
            return HttpNotFound();
        }

        // POST: Lists/Edit/5
        [HttpPost]
        public ActionResult EditList(List list)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(list).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Lists/Lists");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lists/Delete/5
        public ActionResult DeleteList(int id)
        {
            return View();
        }

        // POST: Lists/Delete/5
        [HttpPost]
        public ActionResult DeleteList(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Lists");
            }
            catch
            {
                return View();
            }
        }
    }
}
