using System.Data.Entity;

namespace Repository.DAL
{
    public class DataInitialization : DropCreateDatabaseAlways<DataContext>
	{
		protected override void Seed(DataContext context)
		{

		}
	}
}
