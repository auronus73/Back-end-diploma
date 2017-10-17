using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class StatementsController : Controller
    {
        // GET: Lists
        public ActionResult List(int pageNumber)
        {
            int pageSize = 10;
            var asd = new diplomaEntities();
            var qwe = asd.Statements.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var zxc = asd.Statements.Count();
            return View();
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int id)
        {
            var asd = new diplomaEntities();
            Statement list = asd.Statements.Find(id);
            if (list != null)
            {
                return View(list);
            }
            return HttpNotFound();
        }

        // POST: Lists/Edit/5
        [HttpPost]
        public ActionResult Edit(Statement list)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(list).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lists/Delete/5
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
