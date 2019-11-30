using Repository.Models.Base;

namespace Repository.Models.Odh
{
	public class Odh : ModelBase
	{
		public OdhCategory Category { get; set; }

		public OdhType Type { get; set; }
	}
}
