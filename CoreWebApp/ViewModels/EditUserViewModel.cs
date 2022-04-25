using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
        public List<string> Claims { get; set; } = new();
    }
}
