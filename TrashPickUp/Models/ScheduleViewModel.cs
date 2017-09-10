using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashPickUp.Models
{
    public class ScheduleViewModel
    {
        public List<ExceptionDay> Exceptions { get; set; }
        public List<VacationPeriod> VacationPeriods { get; set; }
        public DefaultTrashSchedule DefaultDay { get; set; }
        public List<string> Days { get; set; }

        public ScheduleViewModel()
        {
            Days = new List<string>();
            Days.Add("Sunday");
            Days.Add("Monday");
            Days.Add("Tuesday");
            Days.Add("Wednesday");
            Days.Add("Thursday");
            Days.Add("Friday");
            Days.Add("Saturday");
        }
    }
}