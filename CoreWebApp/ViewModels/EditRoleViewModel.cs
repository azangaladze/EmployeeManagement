using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.ViewModels
{
    public class EditRoleViewModel
    {
      
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new();



    }
}
