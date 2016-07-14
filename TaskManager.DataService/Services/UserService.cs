using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TaskManager.DataService.Database;
using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public interface IUserService
    {
        UserProfileModel GetUserProfile(int id);
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
                        if (user.UserDetails == null)
                        {
                            user.UserDetails = new UserDetails
                            {
                                Location = "409"
                            };
                        }
                        context.SaveChanges();
                    

                    
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
    }
}