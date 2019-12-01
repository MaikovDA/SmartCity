using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models
{
	public class Gbu : NamedModel
	{
		[Required]
		public string Address { get; set; }

		[Required]
		public double CleanSquare { get; set; }

		[Required]
		public double Lat { get; set; }

		[Required]
		public double Lon { get; set; }
	}
}
