using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models.Odh
{
	public class OdhCategory : NamedModel
	{
		[Required]
		public int Priority { get; set; }
	}
}
