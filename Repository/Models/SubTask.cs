using Repository.Models.Base;

namespace Repository.Models
{
	public class SubTask : ModelBase
	{
		public WorkTask WorkTask { get; set; }

		public Employee Employee { get; set; }

		public CheckType CheckType { get; set; }

		public Route.Route Route { get; set; }

		public Machine Machine { get; set; }

		public Attachment Attachment { get; set; }

		public Material Material { get; set; }
	}
}
