using System.Linq;
using Repository.Models;

namespace Repository.Services
{
	public class GbuService : BaseService
	{
		public Gbu FirstOrDefault()
		{
			return DbContext.Gbus.FirstOrDefault();
		}
	}
}
