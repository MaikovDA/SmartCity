using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models
{
    public class Machine : ModelBase
    {
		public int MachineTypeId { get; set; }

		public ICollection<Attachment> Attachments { get; set; }

		[Required]
	    public MachineType Type { get; set; }

	    public int InventoryNum { get; set; }

	    public string RegNum { get; set; }

		public string BnsoCode { get; set; }
    }
}
