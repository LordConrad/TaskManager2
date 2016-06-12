using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager.DataService.Database;

namespace TaskManager.DataService.Models
{
    public class ApplicationUser : IdentityUser<Int32, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, Int32> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string FullName { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<Int32> { }
    public class ApplicationUserRole : IdentityUserRole<Int32> { }
    public class ApplicationUserClaim : IdentityUserClaim<Int32> { }

    public class ApplicationRole : IdentityRole<Int32, ApplicationUserRole>
    {
        public ApplicationRole() { }

        public ApplicationRole(string name) { Name = name; }
    }

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, Int32, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(AuthContext context)
            : base(context)
        {
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, Int32, ApplicationUserRole>
    {
        public ApplicationRoleStore(AuthContext context)
            : base(context)
        {
        }
    } 
}