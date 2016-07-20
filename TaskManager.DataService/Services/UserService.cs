using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using TaskManager.DataService.Database;
using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;
using TaskManager.DataService.ViewModels;

namespace TaskManager.DataService.Services
{
    public interface IUserService
    {
        UserProfileModel GetUserProfile(int id);
        bool UpdateProfile(UpdateProfileViewModel profile);
    }

    public class UserService : IUserService
    {
        public UserProfileModel GetUserProfile(int id)
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    var user = context.Users.Find(id);
                    if (user != null)
                    {
                        return new UserProfileModel
                        {
                            UserId = user.Id,
                            FullName = user.FullName,
                            Location = user.UserDetails != null ? user.UserDetails.Location : "",
                            Login = user.UserName,
                            Position = user.UserDetails != null ? user.UserDetails.Position : "",
                            Sex = user.UserDetails != null ? user.UserDetails.Sex : "",
                            WorkPhoneNumber = user.UserDetails != null ? user.UserDetails.WorkPhoneNumber : "",
                            CellPhoneNumber = user.UserDetails != null ? user.UserDetails.CellPhoneNumber : ""
                        };
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public bool UpdateProfile(UpdateProfileViewModel profile)
        {
            using (var context = new TaskManagerContext())
            {
                var user = context.Users.Find(int.Parse(profile.UserId));
                if (user != null)
                {
                    IEnumerable<PropertyInfo> props = typeof (UserDetails).GetProperties().Where(x => Attribute.IsDefined(x, typeof (DisplayAttribute)));
                    PropertyInfo prop = props.FirstOrDefault(x => x.CustomAttributes.Any(y => y.NamedArguments.Any(z => z.TypedValue.Value.Equals(profile.Title))));
                    var userDetails = new UserDetails
                    {
                        UserId = int.Parse(profile.UserId),
                    };
                    if (prop == null) return false;
                    prop.SetValue(userDetails, profile.NewValue);
                    var currentProfile = context.UserDetails.Find(userDetails.UserId);
                    EntityState state = currentProfile == null ? EntityState.Added : EntityState.Modified;
                    context.Entry(userDetails).State = EntityState.Added;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}