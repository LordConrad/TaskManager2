using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager2.DataAccess.EFModels;
using TaskManager2.DataAccess.Models;

namespace TaskManager2.DataAccess.Converters
{
    public class SenderTaskConverter
    {
        public static SenderTask Convert(Task t)
        {
            return new SenderTask
            {
                Id = t.TaskId,
                Text = t.TaskText
            };
        }
    }
}