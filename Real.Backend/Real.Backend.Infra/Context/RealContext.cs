using Real.Backend.Domain.Enities;
using Real.Backend.Infra.Mappings;
using Real.Backend.Shared;
using System.Data.Entity;

namespace Real.Backend.Infra.Context
{
	public class RealContext : DbContext
	{
		public RealContext() : base(Runtime.ConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserMap());
		}
	}
}