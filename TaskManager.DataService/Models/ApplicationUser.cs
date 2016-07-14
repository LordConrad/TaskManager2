using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager.DataService.Database;
using TaskManager.DataService.Database.DbModels;

namespace TaskManager.DataService.Models
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string FullName { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public virtual ICollection<TaskEeventLog> Logs { get; set; }
        public virtual ICollection<Database.DbModels.Task> SendedTasks { get; set; }
        public virtual ICollection<Database.DbModels.Task> AssignedTasks { get; set; } 
        public virtual ICollection<Database.DbModels.Comment> Comments { get; set; } 

    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        
    }

    public class ApplicationUserRole : IdentityUserRole<int> { }
    public class ApplicationUserClaim : IdentityUserClaim<int> { }

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public ApplicationRole() { }

        public ApplicationRole(string name) { Name = name; }
    }

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(AuthContext context)
            : base(context)
        {
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(AuthContext context)
            : base(context)
        {
        }
    } 
}