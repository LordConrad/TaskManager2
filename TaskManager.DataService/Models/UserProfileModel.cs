using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.DataService.Models
{
    public class UserProfileModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
    }
}