using CoreWebApp.Models;
using System.Collections.Generic;

namespace CoreWebApp.ViewModels
{
    public class UserClaimsViewModel
    {
        public string UserId { get; set; }
        public List<UserClaim> Claims { get; set; } = new();
    }
}
