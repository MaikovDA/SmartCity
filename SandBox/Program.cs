using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
	[DataContract(Name = "fact")]
	public class Fact
	{
		[DataMember(Name = "temp")]
		public byte Temperature { get; set; }
		[DataMember(Name = "icon")]
		public string ImageSVG { get; set; }
		[DataMember(Name = "wind_speed")]
		public byte WindSpeed { get; set; }
		[DataMember(Name = "pressure_mm")]
		public short AtmospherePressure { get; set; }
		[DataMember(Name = "humidity")]
		public byte HumidityPget { get; set; }
	}

	[DataContract(Name = "forecast")]
	public class Forecast
	{
		[DataMember(Name = "parts")]
		public Parts Parts { get; set; }
	}
	public class Parts
	{
		public string PartsName { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			var weather = new Fact();
			WebRequest request = WebRequest.Create("https://api.weather.yandex.ru/v1/forecast?lat=55.75396&lon=37.620393&extra=true");
			request.Headers.Add("X-Yandex-API-Key: d3003b75-4ff8-41a3-89ac-7fe9f8b814b4");
			WebResponse response = request.GetResponse();
			using (Stream stream = response.GetResponseStream())
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string line = reader.ReadToEnd();

					DataContractJsonSerializer j = new DataContractJsonSerializer(typeof(Fact));
					weather = j.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(line))) as Fact;

				}
			}
		}
	}
}
