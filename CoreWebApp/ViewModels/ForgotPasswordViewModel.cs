using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
