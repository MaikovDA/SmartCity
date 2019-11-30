using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using TeamB.Models;

namespace TeamB.Controllers
{
    public class TaskController : ApiController
    {
        [HttpGet]

        public JsonResult<TaskModel> Get()
        {
            return Json(new TaskModel() { Name = "MainTask" });
        }


    }
}
