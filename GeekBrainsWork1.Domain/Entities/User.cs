using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace GeekBrainsWork1.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Login)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(250)
                .IsRequired();

            HasRequired(x => x.Role);
        }
    }
}
