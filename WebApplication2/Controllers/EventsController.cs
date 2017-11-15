using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2.Models;
using WebApplication2.Views.Shared;

using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult List(PageModel pageModel)
        {
            var context = new diplomaEntities();
            double n = 10;
            int totalPages = Convert.ToInt32(Math.Ceiling((decimal)(context.Events.Count() / n)));
            int pageNumber = Math.Min(Math.Max(pageModel != null ? pageModel.PageNumber : 1, 1), totalPages);
            int pageSize = Math.Min(Math.Max(pageModel.PageSize, 10), 100);
            var model = new DataModel<Event>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = context.Events.OrderBy(m => m.event_id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                TotalItems = context.Events.Count()
            };
            return View(model);
        }


        // GET: Events/Edit/5
        [Referrer]
        public ActionResult Edit(int id)
        {
            var asd = new diplomaEntities();
            Event even = asd.Events.Find(id);
            if (even == null) throw new Exception("Мероприятие не найдено");
            else TempData["referrer"] = ControllerContext.RouteData.Values["referrer"];
            return View(even);
        }

        // GET: Events/Edit/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var asd = new diplomaEntities();
            Event even = asd.Events.Find(id);
            if (even == null) throw new Exception("Мероприятие не найдено");
            return View("Edit", even);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit");
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult Edit(Event even)
        {
            try
            {
                var asd = new diplomaEntities();

                if (asd.Events.Any(m => m.event_id == even.event_id))
                {
                    asd.Entry(even).State = EntityState.Modified;
                }
                else
                {
                    asd.Entry(even).State = EntityState.Added;
                }
                asd.SaveChanges();
                if (TempData["referrer"] != null)
                {
                    return Redirect(TempData["referrer"].ToString());
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Events/Delete/5
        [Referrer]
        public ActionResult Delete(int id)
        {
            try
            {
                var asd = new diplomaEntities();
                Event even = asd.Events.Find(id);
                asd.Entry(even).State = EntityState.Deleted;
                asd.SaveChanges();
                if (TempData["referrer"] != null)
                {
                    return Redirect(TempData["referrer"].ToString());
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        
    }
}
