using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TrashPickUp.Models;

namespace TrashPickUp.Controllers
{
    public class VacationPeriodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VacationPeriod/VacationPeriodIndex
        public ActionResult VacationPeriodIndex()
        {
            var guid = User.Identity.GetUserId();
            return View(db.VacationPeriods.Where(x => x.User.ToString() == guid).ToList());
        }

        /*
        // GET: VacationPeriod/VacationPeriodDetails/5
        public ActionResult VacationPeriodDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacationPeriod vacationPeriod = db.VacationPeriods.Find(id);
            if (vacationPeriod == null)
            {
                return HttpNotFound();
            }
            return View(vacationPeriod);
        }
        */

        // GET: VacationPeriod/VacationPeriodCreate
        public ActionResult VacationPeriodCreate()
        {
            return View();
        }

        // POST: VacationPeriod/VacationPeriodCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VacationPeriodCreate([Bind(Include = "Id,User,StartDate,EndDate")] VacationPeriod vacationPeriod)
        {
            vacationPeriod.User = new Guid(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                vacationPeriod.Id = Guid.NewGuid();
                db.VacationPeriods.Add(vacationPeriod);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a VacationPeriod record");
                return RedirectToAction("VacationPeriodIndex");
            }

            DisplayErrorMessage();
            return View(vacationPeriod);
        }

        // GET: VacationPeriod/VacationPeriodEdit/5
        public ActionResult VacationPeriodEdit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacationPeriod vacationPeriod = db.VacationPeriods.Find(id);
            if (vacationPeriod == null)
            {
                return HttpNotFound();
            }
            return View(vacationPeriod);
        }

        // POST: VacationPeriodVacationPeriod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VacationPeriodEdit([Bind(Include = "Id,User,StartDate,EndDate")] VacationPeriod vacationPeriod)
        {
            vacationPeriod.User = new Guid(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                db.Entry(vacationPeriod).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a VacationPeriod record");
                return RedirectToAction("VacationPeriodIndex");
            }
            DisplayErrorMessage();
            return View(vacationPeriod);
        }

        // GET: VacationPeriod/VacationPeriodDelete/5
        public ActionResult VacationPeriodDelete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacationPeriod vacationPeriod = db.VacationPeriods.Find(id);
            if (vacationPeriod == null)
            {
                return HttpNotFound();
            }
            return View(vacationPeriod);
        }

        // POST: VacationPeriod/VacationPeriodDelete/5
        [HttpPost, ActionName("VacationPeriodDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult VacationPeriodDeleteConfirmed(Guid id)
        {
            VacationPeriod vacationPeriod = db.VacationPeriods.Find(id);
            db.VacationPeriods.Remove(vacationPeriod);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a VacationPeriod record");
            return RedirectToAction("VacationPeriodIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
