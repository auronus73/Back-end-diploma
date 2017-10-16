using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class RewardsController : Controller
    {
        // GET: Rewards
        public ActionResult List()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Rewards;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }

        

        // GET: Rewards/Edit/5
        public ActionResult Edit(int id)
        {
            var asd = new diplomaEntities();
            Reward reward = asd.Rewards.Find(id);
            if (reward != null)
            {
                return View(reward);
            }
            return HttpNotFound();
        }

        // POST: Rewards/Edit/5
        [HttpPost]
        public ActionResult Edit(Reward reward)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(reward).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rewards/Delete/5
        public ActionResult DeleteReward(int id)
        {
            return View();
        }

        // POST: Rewards/Delete/5
        [HttpPost]
        public ActionResult DeleteReward(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
