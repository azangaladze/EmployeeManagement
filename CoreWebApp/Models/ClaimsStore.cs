using System.Collections.Generic;
using System.Security.Claims;

namespace CoreWebApp.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> Claims = new()
        {
            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role", "Edit Role"),
            new Claim("Delete Role", "Delete Role")
        };

    }
}
