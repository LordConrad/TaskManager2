using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database
{
    public class AuthContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public AuthContext() : base("DefaultConnection")
        {
            
        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}