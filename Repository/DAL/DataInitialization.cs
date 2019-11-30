using System.Data.Entity;
using UniStore.Repository.DAL;

namespace Repository.DAL
{
    public class DataInitialization : DropCreateDatabaseAlways<DataContext>
	{
		protected override void Seed(DataContext context)
		{

		}
	}
}
