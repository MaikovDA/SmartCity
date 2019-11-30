using Repository.Models.Base;

namespace Repository.Models
{
	public class WorkTask : NamedModel
	{
		public Gbu Gbu { get; set; }

		public int MaxHourCount { get; set; }
	}
}
