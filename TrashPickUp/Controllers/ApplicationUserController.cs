using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
            return View(db.ApplicationUsers.ToList());
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
