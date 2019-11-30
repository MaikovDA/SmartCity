using System.Collections.Generic;

namespace TeamB.Models
{
	public class WorkTask
	{
		public string Name { get; set; }

		public IEnumerable<SubTask> SubTasks { get; set; }
	}
}