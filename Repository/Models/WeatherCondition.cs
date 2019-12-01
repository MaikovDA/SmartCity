using Repository.Models.Base;

namespace Repository.Models
{
	public class WeatherCondition : ModelBase
	{
		public int? TempMin { get; set; }

		public int? TempMax { get; set; }

		public WeatherEvent? WeatherEvent { get; set; }

		public int? PrecMin { get; set; }

		public int? PrecMax { get; set; }


	}

	public enum WeatherEvent
	{
		Snow = 3,

		Rain = 2,

		Defoliation = 1
	}
}
