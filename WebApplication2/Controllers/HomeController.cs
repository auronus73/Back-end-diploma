using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        EventContext db = new EventContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Event> events = db.Events;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Events = events;
            // возвращаем представление
            return View();

            var asd = new diplomaEntities();

            var qwe = asd.Marks.Where(x => x.subject_id == 12);


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