using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models.Odh
{
	public class Odh : NamedModel
	{
		[Required]
		public OdhCategory Category { get; set; }

		public int CategoryId { get; set; }

		[Required]
		public OdhType Type { get; set; }

		public int TypeId { get; set; }

		public int SquareOnMetr { get; set; }
	}
}
