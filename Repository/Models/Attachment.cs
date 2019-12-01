﻿using System.Collections.Generic;
using Repository.Models.Base;

namespace Repository.Models
{
	public class Attachment : NamedModel
	{
		public ICollection<MachineType> MachineTypes { get; set; }

		public ICollection<WorkType> WorkTypes { get; set; }
	}
}
