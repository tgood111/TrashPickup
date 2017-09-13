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
    public class ExceptionDayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExceptionDay/ExceptionDayIndex
        public ActionResult ExceptionDayIndex()
        {
            var guid = User.Identity.GetUserId();
            return View(db.ExceptionDays.Where(x => x.User.ToString() == guid).ToList());
        }

        /*
        // GET: ExceptionDay/ExceptionDayDetails/5
        public ActionResult ExceptionDayDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExceptionDay exceptionDay = db.ExceptionDays.Find(id);
            if (exceptionDay == null)
            {
                return HttpNotFound();
            }
            return View(exceptionDay);
        }
        */

        // GET: ExceptionDay/ExceptionDayCreate
        public ActionResult ExceptionDayCreate()
        {
            return View();
        }

        // POST: ExceptionDay/ExceptionDayCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExceptionDayCreate([Bind(Include = "ExceptionDays,Id,User,Exception")] ExceptionDay exceptionDay)
        {
            exceptionDay.User = new Guid(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                exceptionDay.Id = Guid.NewGuid();
                db.ExceptionDays.Add(exceptionDay);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ExceptionDay record");
                return RedirectToAction("ExceptionDayIndex");
            }

            DisplayErrorMessage();
            return View(exceptionDay);
        }

        // GET: ExceptionDay/ExceptionDayEdit/5
        public ActionResult ExceptionDayEdit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExceptionDay exceptionDay = db.ExceptionDays.Find(id);
            if (exceptionDay == null)
            {
                return HttpNotFound();
            }
            return View(exceptionDay);
        }

        // POST: ExceptionDayExceptionDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExceptionDayEdit([Bind(Include = "ExceptionDays,Id,User,Exception")] ExceptionDay exceptionDay)
        {
            exceptionDay.User = new Guid(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                db.Entry(exceptionDay).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a ExceptionDay record");
                return RedirectToAction("ExceptionDayIndex");
            }
            DisplayErrorMessage();
            return View(exceptionDay);
        }

        // GET: ExceptionDay/ExceptionDayDelete/5
        public ActionResult ExceptionDayDelete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExceptionDay exceptionDay = db.ExceptionDays.Find(id);
            if (exceptionDay == null)
            {
                return HttpNotFound();
            }
            return View(exceptionDay);
        }

        // POST: ExceptionDay/ExceptionDayDelete/5
        [HttpPost, ActionName("ExceptionDayDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ExceptionDayDeleteConfirmed(Guid id)
        {
            ExceptionDay exceptionDay = db.ExceptionDays.Find(id);
            db.ExceptionDays.Remove(exceptionDay);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a ExceptionDay record");
            return RedirectToAction("ExceptionDayIndex");
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
