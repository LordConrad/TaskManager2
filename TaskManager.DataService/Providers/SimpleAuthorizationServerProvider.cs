using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TaskManager.DataService.Database;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }



        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            using (var authRepository = new AuthRepository())
            {
                ApplicationUser user = await authRepository.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect");
                    return;
                }

                ClaimsIdentity oAuthIdentity = await authRepository.CreateIdentityAsync(user, context.Options.AuthenticationType);
                List<Claim> roles = oAuthIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                AuthenticationProperties properties = CreateProperties(user.UserName, Newtonsoft.Json.JsonConvert.SerializeObject(roles.Select(x => x.Value)));
                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);

            //    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            //    foreach (Claim role in roles)
            //    {
            //        identity.AddClaim(new Claim(ClaimTypes.Role, role.Value));
            //    }
            }

            //context.Validated(identity);
        }

        public static AuthenticationProperties CreateProperties(string userName, string Roles)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                {"userName", userName},
                {"roles", Roles}
            };
            return new AuthenticationProperties(data);
        }
    }
}