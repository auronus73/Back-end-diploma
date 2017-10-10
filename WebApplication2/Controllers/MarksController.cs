using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class MarksController : Controller
    {
        // GET: Marks
        public ActionResult Marks()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Marks;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }


        // GET: Marks/Create
        public ActionResult CreateMark()
        {
            return View();
        }

        // POST: Marks/Create
        [HttpPost]
        public ActionResult CreateMark(Mark mark)
        {
            var asd = new diplomaEntities();
            try
            {
                // TODO: Add insert logic here
                asd.Marks.Add(mark);
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Marks/Marks");
            }
            catch
            {
                return View(asd.Marks);
            }
        }

        // GET: Marks/Edit/5
        public ActionResult EditMark(int id)
        {
            var asd = new diplomaEntities();
            Mark mark = asd.Marks.Find(id);
            if (mark != null)
            {
                return View(mark);
            }
            return HttpNotFound();
        }

        // POST: Marks/Edit/5
        [HttpPost]
        public ActionResult EditMark(Mark mark)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(mark).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Marks");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marks/Delete/5
        public ActionResult DeleteMark(int id)
        {
            return View();
        }

        // POST: Marks/Delete/5
        [HttpPost]
        public ActionResult DeleteMark(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Marks");
            }
            catch
            {
                return View();
            }
        }
    }
}
