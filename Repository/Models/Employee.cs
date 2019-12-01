using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models
{
	public class Employee : ModelBase
	{
		[Required]
		public string Fio { get; set; }

		[Required]
		public int Code { get; set; }

		[Required]
		public Gbu Gbu { get; set; }
	}
}
