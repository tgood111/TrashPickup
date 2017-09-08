using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashPickUp.Models
{
    public class ExceptionDays
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public DateTime Exception { get; set; }
    }
}