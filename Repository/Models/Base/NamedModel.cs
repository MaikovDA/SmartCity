using System.ComponentModel.DataAnnotations;

namespace Repository.Models.Base
{
	public abstract class NamedModel : ModelBase
	{
		[Required]
		public string Name { get; set; }

		public string Description { get; set; }
	}
}
