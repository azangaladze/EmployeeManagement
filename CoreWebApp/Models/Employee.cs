using CoreWebApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Work Email")]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }
        public string PhotoPath { get; set; }

    }
}
