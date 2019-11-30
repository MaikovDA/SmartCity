using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repository.Models;

namespace Repository.DAL
{
	public class DataContext : DbContext
	{
        public DbSet<Machine> Machines { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<CleanMethod> CleanMethods { get; set; }

        public DbSet<WorkType> WorkTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
		}
	}
}
