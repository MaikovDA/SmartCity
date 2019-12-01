using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models.Route
{
	public class Node : ModelBase
	{
		[Required]
		public double X { get; set; }

		[Required]
		public double Y { get; set; }
	}
}
