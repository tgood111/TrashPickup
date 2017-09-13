using System;
using System.ComponentModel.DataAnnotations;

namespace TrashPickUp.Models
{
    [MetadataType(typeof(ExceptionDayMetadata))]
    public partial class ExceptionDay
    {
    }

    public partial class ExceptionDayMetadata
    {
        [Display(Name = "ExceptionDays")]
        public ExceptionDay ExceptionDays { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "User")]
        public Guid User { get; set; }

        [Display(Name = "Exception")]
        public DateTime Exception { get; set; }

    }
}
