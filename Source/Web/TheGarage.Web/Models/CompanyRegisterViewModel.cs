using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGarage.Web.Models
{
    public class CompanyRegisterViewModel
    {
        [DefaultValue(true)]
        public bool IsCompany { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Required]
        [Display(Name = "Number of places")]
        public int PlacesCount { get; set; }


        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "Message")]
        public string CustomMessage { get; set; }

        // This property will hold all available States for selection
        public string States { get; set; }

        // This property will hold all available Cities for selection
        public string Cities { get; set; }

        // This property will hold all available Garages for selection
        public string Garages { get; set; }
    }
}