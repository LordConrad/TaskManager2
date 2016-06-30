using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TaskManager.DataService.Database;
using TaskManager.DataService.Models;
using TaskManager.DataService.Services;

namespace TaskManager.DataService.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly IUserService _userService;
        private KeyValuePair<string, string> _userExistsError = new KeyValuePair<string, string>("Name asd is already taken.", "Такой логин уже зарегистрирован");

        public AccountController()
        {
            _userService = new UserService();
        }

        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register(UserLoginModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await this.AppUserManager.CreateAsync(new ApplicationUser {UserName = userModel.Username, FullName = userModel.FullName}, userModel.Password);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }

        [Authorize]
        [Route("getuser/{id:int}")]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userService.GetUserProfile(id);
            if (user != null) return Ok(user);
            return NotFound();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        string errMessage = error;
                        if(error.Equals(_userExistsError.Key))
                        {
                            errMessage = _userExistsError.Value;
                        }
                        ModelState.AddModelError(String.Empty, errMessage);
                    }
                }
                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
        
    }
}