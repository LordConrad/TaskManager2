using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManager(new ApplicationRoleStore(context.Get<AuthContext>()));
            return appRoleManager;
        }
    }
}