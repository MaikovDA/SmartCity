using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models
{
	public class MachineType : NamedModel
	{
		[Required]
		public int FreeSpeed { get; set; }

		[Required]
		public int WorkSpeed { get; set; }

		[Required]
		public int GazolineVol { get; set; }

		[Required]
		public int GazolineConsumption { get; set; }

		public int? BunkerVol { get; set; }

		public ICollection<WorkType> WorkTypes { get; set; }

		public ICollection<Attachment> Attachments { get; set; }
	}
}
