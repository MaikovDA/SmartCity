using Repository.Models.Base;

namespace Repository.Models.Odh
{
	public class Odh : NamedModel
	{
		public OdhCategory Category { get; set; }

		public OdhType Type { get; set; }

		public int SquareOnMetr { get; set; }
	}
}
