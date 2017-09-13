using System;
using System.ComponentModel.DataAnnotations;

namespace TrashPickUp.Models
{
    [MetadataType(typeof(ApplicationUserMetadata))]
    public partial class ApplicationUser
    {
    }

    public partial class ApplicationUserMetadata
    {
        [Display(Name = "Claims")]
        public IdentityUserClaim Claims { get; set; }

        [Display(Name = "Logins")]
        public IdentityUserLogin Logins { get; set; }

        [Display(Name = "Roles")]
        public IdentityUserRole Roles { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "PasswordHash")]
        public string PasswordHash { get; set; }

        [Display(Name = "SecurityStamp")]
        public string SecurityStamp { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "LockoutEndDateUtc")]
        public DateTime LockoutEndDateUtc { get; set; }

        [Display(Name = "LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "AccessFailedCount")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

    }
}
