using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Converters
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