using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TaskManager.DataService.Database;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Controllers
{
    public class RolesController : BaseApiController
    {
        [Route("{id:int}", Name = "GetRoleById")]
        public IHttpActionResult GetRole(int id)
        {
            var role = this.RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                return Ok(new ApplicationRole { Id = role.Result.Id, Name = role.Result.Name });
            }
            return NotFound();
        }
    }
}
