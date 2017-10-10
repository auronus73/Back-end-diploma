using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        public int id = 0;
        // GET: Students
        public ActionResult Students()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Students;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }


        // GET: Students/Create
        [HttpGet]
        public ActionResult CreateStudent()
        {
                return View(id);
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            var asd = new diplomaEntities();
            try
            {
                // TODO: Add insert logic here
               
                asd.Students.Add(student);
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Students/Students");
            }
            catch
            {
                return View(asd.Students);
            }
        }

        // GET: Students/Edit/5
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var asd = new diplomaEntities();
            Student student = asd.Students.Find(id);
            if (student != null)
            {
                return View(student);
            }
            return HttpNotFound();
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(student).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Students");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                // TODO: Add delete logic here
                var asd = new diplomaEntities();
                asd.Entry(student).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Students/Students");
            }
            catch
            {
                return View();
            }
        }
    }
}
