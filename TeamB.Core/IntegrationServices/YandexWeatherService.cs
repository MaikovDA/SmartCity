using System.IO;
using System.Net;

namespace TeamB.Core.IntegrationServices
{
	public class YandexWeatherService
	{
		public string GetJson(double lat, double lon)
		{
			string requestString = "https://api.weather.yandex.ru/v1/forecast?lat=" +
								   lat.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
								   + "&lon=" + lon.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "&extra=true";

			var request = WebRequest.Create(requestString);
			request.Headers.Add("X-Yandex-API-Key: d3003b75-4ff8-41a3-89ac-7fe9f8b814b4");
			var response = request.GetResponse();
			using (var stream = response.GetResponseStream())
			{
				if (stream != null)
					using (var reader = new StreamReader(stream))
					{
						return reader.ReadToEnd();
					}

				return string.Empty;
			}
		}
	}
}
