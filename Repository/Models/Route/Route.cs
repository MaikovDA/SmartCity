using System.Collections.Generic;
using Repository.Models.Base;

namespace Repository.Models.Route
{
	public class Route : ModelBase
	{
		public ICollection<Edge> Edges { get; set; } 
	}
}
