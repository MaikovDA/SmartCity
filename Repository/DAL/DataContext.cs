using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repository.Models;
using Repository.Models.Odh;
using Repository.Models.Route;

namespace Repository.DAL
{
	public class DataContext : DbContext
	{
        public DbSet<Machine> Machines { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<CleanMethod> CleanMethods { get; set; }

        public DbSet<Node> Nodes { get; set; }

		public DbSet<Route> Routes { get; set; }

		public DbSet<Odh> Odhs { get; set; }

		public DbSet<OdhNode> OdhNodes { get; set; }

		public DbSet<OdhCategory> OdhsCategories { get; set; }

		public DbSet<Gbu> Gbus { get; set; }

		public DbSet<WorkTask> WorkTasks { get; set; }

		public DbSet<SubTask> SubTasks { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Material> Materials { get; set; }

		public DbSet<Edge> Edges { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
		}
	}
}
