using CoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.ViewModels
{
    public class EmployeeCreateViewModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Work Email")]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }
        public IFormFile Photo { get; set; }
    }
}
