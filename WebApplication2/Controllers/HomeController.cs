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
        EventContext db_event = new EventContext();
        StudentContext db_student = new StudentContext();

        public ActionResult Index()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Students;
            
            // получаем из бд все объекты Book
            IEnumerable<Student> students = db_student.Students;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Students = students;
            // возвращаем представление
            return View(qwe);
        }

        public ActionResult EditStudent(int id)
        {
            ViewBag.student_id = id;
            return View();
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