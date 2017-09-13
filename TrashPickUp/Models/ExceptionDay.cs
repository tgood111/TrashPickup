using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashPickUp.Models
{
    public partial class ExceptionDay
    {
        [Key]
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public DateTime Exception { get; set; }

        public virtual List<ExceptionDay> ExceptionDays { get; set; }
    }
}