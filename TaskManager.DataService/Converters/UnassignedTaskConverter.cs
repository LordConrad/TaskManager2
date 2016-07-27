using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Converters
{
	public class UnassignedTaskConverter
	{
        public static UnassignedTask Convert(Task t)
        {
             return new UnassignedTask
             {
                 Id = t.TaskId,
                 Text = t.TaskText,
                 CreateDateTime = t.CreateDate,
                 SenderName = t.TaskSender.FullName
             };
        }
	}
}