using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        public int id = 0;
        // GET: Students
        public ActionResult List(PageModel pageModel)
        {
            var context = new diplomaEntities();
            double n = 10;
            int totalPages = Convert.ToInt32(Math.Ceiling((decimal)(context.Students.Count() / n)));
            int pageNumber = Math.Min(Math.Max(pageModel != null ? pageModel.PageNumber : 1,1), totalPages);
            int pageSize = Math.Min(Math.Max(pageModel.PageSize, 10), 100);
            var model = new DataModel<Student>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = context.Students.OrderBy(m => m.student_id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                TotalItems = context.Students.Count()
            };
            return View(model);
        }

        // GET: Students/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var asd = new diplomaEntities();
            Student student = asd.Students.Find(id);
            if (student == null) throw new Exception("Студент не найден");
            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit");
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                var asd = new diplomaEntities();

                if (asd.Students.Any(m => m.student_id == student.student_id))
                {
                    asd.Entry(student).State = EntityState.Modified;
                }
                else
                {
                    asd.Entry(student).State = EntityState.Added;
                }
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var asd = new diplomaEntities();
                Student student = asd.Students.Find(id);
                asd.Entry(student).State = EntityState.Deleted;
                asd.SaveChanges();
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
