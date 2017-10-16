﻿using System;
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
        public ActionResult List()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Students;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }

        // GET: Students/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var asd = new diplomaEntities();
            Student student = asd.Students.Find(id) ?? new Student();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                var asd = new diplomaEntities();

                if (asd.Students.Any(m=> m.student_id == student.student_id) )
                {
                    asd.Entry(student).State = EntityState.Modified;
                }
                else
                {
                    asd.Entry(student).State = EntityState.Added;
                }
                

                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
