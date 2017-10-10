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
        public ActionResult Rewards()
        {
            var asd = new diplomaEntities();
            var qwe = asd.Rewards;
            //var temp = (from c in asd.Students select c.student_id).Max();
            //id = Convert.ToInt32(temp);
            return View(qwe);
        }

        

        // GET: Rewards/Create
        public ActionResult CreateReward()
        {
            return View();
        }

        // POST: Rewards/Create
        [HttpPost]
        public ActionResult CreateReward(Reward reward)
        {
            var asd = new diplomaEntities();
            try
            {
                // TODO: Add insert logic here

                asd.Rewards.Add(reward);
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Rewards/Rewards");
            }
            catch
            {
                return View(asd.Rewards);
            }
        }

        // GET: Rewards/Edit/5
        public ActionResult EditReward(int id)
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
        public ActionResult EditReward(Reward reward)
        {
            try
            {
                var asd = new diplomaEntities();
                asd.Entry(reward).State = EntityState.Modified;
                // сохраняем в бд все изменения
                asd.SaveChanges();
                return RedirectToAction("Rewards");
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
