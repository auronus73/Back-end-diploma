using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Students;
            return View(qwe);
        }

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

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            var asd = new diplomaEntities();
            asd.Entry(student).State = EntityState.Modified;
            // сохраняем в бд все изменения
            asd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}