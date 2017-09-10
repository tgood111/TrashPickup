using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashPickUp.Models
{
    public class VacationPeriod
    {
        [Key]
        public Guid Id { get; set; }

        public Guid User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual List<DateTime> VacationPeriods { get; set; }
    }
}