namespace GeekBrainsWork1.DAL.Migrations
{
    using GeekBrainsWork1.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GeekBrainsWork1.DAL.Context.GeekBrainsWork1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GeekBrainsWork1.DAL.Context.GeekBrainsWork1Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            context.Employee.AddOrUpdate(x => x.Id,
                new Employee () { Id = 1, FirstName = "Dmitriy", SurName = "Gorbovskiy", Patronymie = "Vladimirovich", Age = 26, PositionId = 1},
                new Employee() { Id = 2, FirstName = "Denis", SurName = "Gorbovskiy", Patronymie = "Vladimirovich", Age = 18, PositionId = 2 }
                );

            context.Position.AddOrUpdate(x => x.Id,
                new Position () { Id = 1, Name = "Director"},
                new Position() { Id = 2, Name = "Manager" }
                );

            context.User.AddOrUpdate(x => x.Id,
                new User () { Id = 1, Login = "admin", Password = "12345", RoleId = 1,},
                new User() { Id = 2, Login = "user", Password = "12345", RoleId = 2, }
                );

            context.Role.AddOrUpdate(x => x.Id,
                new Role () { Id = 1, Name = "asministrator"},
                new Role() { Id = 2, Name = "user" }
                );

            context.SaveChanges();
        }
    }
}
