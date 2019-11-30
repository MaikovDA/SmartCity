using System.Runtime;

namespace TeamB.Models
{
	public class SubTask
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public TaskStatus Status { get; set; }
	}

	public enum TaskStatus
	{
		Completed = 0,

		Failed =1
	}
}