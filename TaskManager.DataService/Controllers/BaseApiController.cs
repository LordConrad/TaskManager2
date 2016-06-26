using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using TaskManager.DataService.Database;

namespace TaskManager.DataService.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly ApplicationRoleManager _roleManager = null;
        private readonly ApplicationUserManager _appUserManager = null;

        protected ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
        }
        
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
    }
}