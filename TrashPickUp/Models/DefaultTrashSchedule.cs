using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashPickUp.Models
{
    public class DefaultTrashSchedule
    {
        [Key]
        public Guid User { get; set; }
        public DayOfWeek Day { get; set; }

        public virtual List<DefaultTrashSchedule> DefaulTrashSchedules { get; set; }
    }
}