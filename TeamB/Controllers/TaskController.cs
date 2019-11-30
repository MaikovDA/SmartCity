using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using TeamB.Models;

namespace TeamB.Controllers
{
    public class TaskController : ApiController
    {
        [HttpGet]

        public JsonResult<WorkTask> Get()
        {
            return Json(new WorkTask
            {
	            Name = "MainTask",
	            SubTasks = new List<SubTask>
	            {
		            new SubTask {Id=1, Name = "Test", Status = TaskStatus.Completed},
					new SubTask {Id=1, Name = "Test", Status = TaskStatus.Failed}
				}
            });
        }


    }
}

