using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository.Models.Base;

namespace Repository.Models
{
	public class WorkType : NamedModel
	{
		[Required]
		public CleanMethod CleanMethod { get; set; }

		public int CleanMethodId { get; set; }

		public TimeSpan? RegTimeStart { get; set; }

		public TimeSpan? RegTimeEnd { get; set; }

		public Season? SeasonCode { get; set; }

		public Odh.Odh Odh { get; set; }

		public int? OdhId { get; set; }

		[Required]
		public int DayOperationCount { get; set; }

		public int? Weigth { get; set; }

		public WeatherCondition WeatherCondition { get; set; }

		public int? WeatherConditionId { get; set; }

		public ICollection<MachineType> MachineTypes { get; set; }

		public ICollection<Attachment> Attachments { get; set; }

		[Required]
		public CheckType CheckType { get; set; }

		public int CheckTypeId { get; set; }
	}


	public enum Season
	{
		Winter = 1,

		Summer = 2
	}
}
