using Repository.Models.Base;

namespace Repository.Models.Odh
{
	public class OdhCategory : NamedModel
	{
		public int Priority { get; set; }

		public int Code { get; set; }
	}
}
