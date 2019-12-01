using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models
{
	public class SubTask : ModelBase
	{
		[Required]
		public WorkTask WorkTask { get; set; }

		[Required]
		public Employee Employee { get; set; }

		public CheckType CheckType { get; set; }

		[Required]
		public Route.Route Route { get; set; }

		[Required]
		public Machine Machine { get; set; }

		[Required]
		public Attachment Attachment { get; set; }

		public Material Material { get; set; }
	}
}
