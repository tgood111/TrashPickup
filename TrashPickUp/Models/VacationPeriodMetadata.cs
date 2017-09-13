using System;
using System.ComponentModel.DataAnnotations;

namespace TrashPickUp.Models
{
    [MetadataType(typeof(VacationPeriodMetadata))]
    public partial class VacationPeriod
    {
    }

    public partial class VacationPeriodMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "User")]
        public Guid User { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

    }
}
