﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class SubjectsController : Controller
    {
        public int id = 0;
        // GET: Students
        public ActionResult Subjects()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Subjects;
            return View(qwe);
        }


        // GET: Students/Create
        [HttpGet]
        public ActionResult CreateSubject()
        {
            return View(id);
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult CreateSubject(Subject item)
        {
            var asd = new diplomaEntities();
            try
            {
                // TODO: Add insert logic here

                asd.Subjects.Add(item);
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("/Subjects");
            }
            catch
            {
                return View(asd.Subjects);
            }
        }

        // GET: Students/Edit/5
        [HttpGet]
        public ActionResult EditSubject(int id)
        {
            var asd = new diplomaEntities();
            Subject subject = asd.Subjects.Find(id);
            if (subject != null)
            {
                return View(subject);
            }
            return HttpNotFound();
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult EditSubject(Subject subject)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(subject).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("/Subjects");
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
        public ActionResult Delete(Subject subject)
        {
            try
            {
                // TODO: Add delete logic here
                var asd = new diplomaEntities();
                asd.Entry(subject).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("/Subjects");
            }
            catch
            {
                return View();
            }
        }
    }
}
