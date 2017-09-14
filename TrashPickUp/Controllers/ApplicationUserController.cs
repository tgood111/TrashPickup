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
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUser/ApplicationUserIndex
        public ActionResult ApplicationUserIndex()
        {
            // To get a list of users who have a pickup day of today
            // Can't have exception day overriding this day
            // Can't be on vacation
            // Must be in a certain zip code.
            var context = new ApplicationDbContext();
            var guid = User.Identity.GetUserId();
            var trashPerson = context.Users.FirstOrDefault(x => x.Id.ToString() == guid);
            if (trashPerson == null)
                return View();

            List<ApplicationUser> relevantPickups = new List<ApplicationUser>();
            foreach (var user in context.Users.ToList())
            {
                var todaysDate = DateTime.Today;
                
                System.Globalization.CultureInfo ci =
                    System.Threading.Thread.CurrentThread.CurrentCulture;
                DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                DayOfWeek today = DateTime.Now.DayOfWeek;
                DateTime startOfWeek = DateTime.Now.AddDays(-(today - fdow)).Date;
                DateTime lastDayOfWeek = startOfWeek.AddDays(6);

                if (context.VacationPeriods.FirstOrDefault(x => x.User.ToString() == user.Id.ToString() &&
                                                       todaysDate <= x.EndDate && todaysDate >= x.StartDate) != null)
                {
                    continue;
                } else if (context.ExceptionDays.FirstOrDefault(x => x.User.ToString() == user.Id.ToString() &&
                                                     x.Exception != todaysDate && startOfWeek <= x.Exception &&
                                                     lastDayOfWeek >= x.Exception) != null)
                {
                    continue;
                }
                else if (context.ExceptionDays.FirstOrDefault(x => x.User.ToString() == user.Id.ToString() &&
                                                                   x.Exception == todaysDate) != null)
                {
                    if (user.Zip == trashPerson.Zip)
                        relevantPickups.Add(user);
                    continue;
                }
                else if (context.DefaultTrashSchedules.FirstOrDefault(
                             x => x.User.ToString() == user.Id.ToString() && x.Day == todaysDate.DayOfWeek) == null)
                {
                    continue;
                }

                if (user.Zip == trashPerson.Zip) 
                    relevantPickups.Add(user);
            }
            return View(relevantPickups);
        }

        /*
        // GET: ApplicationUser/ApplicationUserDetails/5
        public ActionResult ApplicationUserDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
        */

        // GET: ApplicationUser/ApplicationUserCreate
        //public ActionResult ApplicationUserCreate()
        //{
        //    return View();
        //}

        // POST: ApplicationUser/ApplicationUserCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ApplicationUserCreate([Bind(Include = "Claims,Logins,Roles,Id,Street,City,Zip,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ApplicationUsers.Add(applicationUser);
        //        db.SaveChanges();
        //        DisplaySuccessMessage("Has append a ApplicationUser record");
        //        return RedirectToAction("ApplicationUserIndex");
        //    }

        //    DisplayErrorMessage();
        //    return View(applicationUser);
        //}

        // GET: ApplicationUser/ApplicationUserEdit/5
        //public ActionResult ApplicationUserEdit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationUser);
        //}

        // POST: ApplicationUserApplicationUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ApplicationUserEdit([Bind(Include = "Claims,Logins,Roles,Id,Street,City,Zip,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(applicationUser).State = EntityState.Modified;
        //        db.SaveChanges();
        //        DisplaySuccessMessage("Has update a ApplicationUser record");
        //        return RedirectToAction("ApplicationUserIndex");
        //    }
        //    DisplayErrorMessage();
        //    return View(applicationUser);
        //}

        // GET: ApplicationUser/ApplicationUserDelete/5
        //public ActionResult ApplicationUserDelete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationUser);
        //}

        // POST: ApplicationUser/ApplicationUserDelete/5
        //[HttpPost, ActionName("ApplicationUserDelete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult ApplicationUserDeleteConfirmed(string id)
        //{
        //    ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //    db.ApplicationUsers.Remove(applicationUser);
        //    db.SaveChanges();
        //    DisplaySuccessMessage("Has delete a ApplicationUser record");
        //    return RedirectToAction("ApplicationUserIndex");
        //}

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
