using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _context;
        private readonly ApplicationUserManager _userManager;
        
        public AuthRepository()
        {
            _context = new AuthContext();
            _userManager = new ApplicationUserManager(new ApplicationUserStore(_context));
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authType)
        {
            return _userManager.CreateIdentityAsync(user, authType);
        }

        public async Task<IdentityResult> RegisterUser(UserLoginModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Username
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<ApplicationUser> FindUser(string username, string password)
        {
            try
            {
                ApplicationUser user = await _userManager.FindAsync(username, password);
                return user;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }
    }
}