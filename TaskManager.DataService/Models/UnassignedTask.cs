using System;

namespace TaskManager.DataService.Models
{
	public class UnassignedTask
	{
	    public int Id { get; set; }
	    public string Text { get; set; }
	    public string SenderName { get; set; }
	    public DateTime CreateDateTime { get; set; }
	}
}