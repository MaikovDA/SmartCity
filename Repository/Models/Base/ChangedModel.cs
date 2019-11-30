using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models.Base
{
	public abstract class ChangedModel : ModelBase
	{
		[Required]
		public DateTime ChangeDate { get; set; }

		public ChangedModel()
		{
			ChangeDate = DateTime.Now;
		}
	}
}