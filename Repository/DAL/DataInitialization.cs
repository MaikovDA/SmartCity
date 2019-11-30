using System.Data.Entity;
using System.Linq;
using Repository.Models;

namespace Repository.DAL
{
    public class DataInitialization : DropCreateDatabaseAlways<DataContext>
	{
		protected override void Seed(DataContext context)
		{
			context.CleanMethods.Add(new CleanMethod() {Name = "Ручной"});
			context.CleanMethods.Add(new CleanMethod() { Name = "Механизированный" });

			context.SaveChanges();
		}
	}
}
