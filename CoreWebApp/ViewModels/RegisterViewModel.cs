using CoreWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "account")]
        [ValidEmailDomain(allowedDomain: "test.com", ErrorMessage = "Only test.com domain is allowed")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }

    }
}
