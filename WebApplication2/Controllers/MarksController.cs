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
        public ActionResult List()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Marks;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }


        // GET: Marks/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit(Mark mark)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(mark).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marks/Delete/5
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
