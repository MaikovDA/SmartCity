using System.IO;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Repository.Services;
using TeamB.Core.IntegrationServices;

namespace TeamB.Controllers
{
    public class YandexWeatherController : ApiController
    {
	    public JsonResult<string> Get(double lat, double lon)
	    {
		    return Json(new YandexWeatherService().GetJson(lat, lon));
	    }

		public JsonResult<string> GetGbu()
		{
			var gbu = new GbuService().FirstOrDefault();
			return Json(new YandexWeatherService().GetJson(gbu.Lat, gbu.Lon));
		}
	}
}
