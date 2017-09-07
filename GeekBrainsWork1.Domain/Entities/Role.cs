using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace GeekBrainsWork1.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
