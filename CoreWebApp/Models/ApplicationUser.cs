using Microsoft.AspNetCore.Identity;

namespace CoreWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
