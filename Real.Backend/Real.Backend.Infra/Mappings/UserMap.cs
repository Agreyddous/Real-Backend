using Real.Backend.Domain.Enities;
using System.Data.Entity.ModelConfiguration;

namespace Real.Backend.Infra.Mappings
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			ToTable("Users");
			HasKey(x => x.Id);

			Property(x => x.Login.Username).IsRequired().HasMaxLength(20).HasColumnName("Username");
			Property(x => x.Login.Password).IsRequired().HasColumnName("Password");

			Property(x => x.Name.Firstname).IsRequired().HasMaxLength(15).HasColumnName("Firstname");
			Property(x => x.Name.Middlename).HasMaxLength(30).HasColumnName("Middlename");
			Property(x => x.Name.Lastname).IsRequired().HasMaxLength(15).HasColumnName("Lastname");

			Property(x => x.Email.Address).IsRequired().HasColumnName("Email");

			Property(x => x.Gender).IsRequired().HasColumnName("Gender");
			Property(x => x.Birthday).IsRequired().HasColumnName("Birthday");

			Property(x => x.CreatedOn).IsRequired().HasColumnName("CreatedOn");
			Property(x => x.Active).IsRequired().HasColumnName("Active");
		}
	}
}