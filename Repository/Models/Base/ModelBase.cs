using System.ComponentModel.DataAnnotations;

namespace Repository.Models.Base
{
	public abstract class ModelBase
	{
		[Key]
		public int Id { get; set; }
	}
}
