using Repository.Models.Base;

namespace Repository.Models.Route
{
	public class Edge : ModelBase
	{
		public Node StartNode { get; set; }

		public Node EndNode { get; set; }

		public Route Route { get; set; }
	}
}
