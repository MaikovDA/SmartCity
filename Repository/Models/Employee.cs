using Repository.Models.Base;

namespace Repository.Models
{
	public class Employee : ModelBase
	{
		public string Fio { get; set; }

		public int Code { get; set; }

		public Gbu Gbu { get; set; }
	}
}
