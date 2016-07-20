using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.DataService.ViewModels
{
    public class UpdateProfileViewModel
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string NewValue { get; set; }
    }
}