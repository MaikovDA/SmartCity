using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;
using Repository.Models.Route;

namespace Repository.Models.Odh
{
	public class OdhNode : ModelBase
	{
		public Odh Odh { get; set; }

		public Node Node { get; set; }
	}
}
