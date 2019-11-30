using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UniStore.Repository.DAL
{
	public class DataContext : DbContext
	{


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
		}
	}
}
