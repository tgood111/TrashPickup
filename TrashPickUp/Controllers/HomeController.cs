using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using TrashPickUp.Models;

namespace TrashPickUp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Schedule()
        {
            var dbContext = new ApplicationDbContext();
            var model = new ScheduleViewModel();
            var guid = User.Identity.GetUserId();
            model.Exceptions = dbContext.ExceptionDays.Where(x => x.User.ToString() == guid).ToList();
            model.VacationPeriods = dbContext.VacationPeriods.Where(x => x.User.ToString() == guid).ToList();
            model.DefaultDay = dbContext.DefaultTrashSchedules.FirstOrDefault(x => x.User.ToString() == guid);
            return View(model); 
        }

        [HttpPost]
        public void DefaultScheduleForm(string DateChoice)
        {
            var guid = User.Identity.GetUserId();
            int value = 0;
            if (DateChoice == "Sunday")
            {
                value = 0;
            }
            if (DateChoice == "Monday")
            {
                value = 1;
            }
            if (DateChoice == "Tuesday")
            {
                value = 2;
            }
            if (DateChoice == "Wednesday")
            {
                value = 3;
            }
            if (DateChoice == "Thursday")
            {
                value = 4;
            }
            if (DateChoice == "Friday")
            {
                value = 5;
            }
            if (DateChoice == "Saturday")
            {
                value = 6;
            }

            using (var db = new ApplicationDbContext())
            {
                var result = db.DefaultTrashSchedules.SingleOrDefault(b => b.User.ToString() == guid);
                if (result != null)
                {
                    result.Day = (DayOfWeek) value;
                }
                else
                {
                    DefaultTrashSchedule d = new DefaultTrashSchedule();
                    d.User = new Guid(guid);
                    d.Day = (DayOfWeek) value;
                    db.DefaultTrashSchedules.Add(d);
                }
                db.SaveChanges();
            }
        }

        public ActionResult Navbar()
        {
            var model = new NavBarViewModel()
            {
                Administrator = User.IsInRole("Admin"),
                User = User.IsInRole("User")
            };
            return PartialView(model);
        }

        public ActionResult Index()
        {
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