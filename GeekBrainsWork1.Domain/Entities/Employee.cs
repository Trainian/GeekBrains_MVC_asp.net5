using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrainsWork1.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronymie { get; set; }
        public int Age { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }

    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.FirstName)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.SurName)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Patronymie)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Age)
                .IsRequired();

            HasRequired(x => x.Position);

        }
    }
}
