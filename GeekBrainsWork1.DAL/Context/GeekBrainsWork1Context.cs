namespace GeekBrainsWork1.DAL.Context
{
    using GeekBrainsWork1.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GeekBrainsWork1Context : DbContext
    {
        // Контекст настроен для использования строки подключения "GeekBrainsWork1Context" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "GeekBrainsWork1.DAL.Context.GeekBrainsWork1Context" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "GeekBrainsWork1Context" 
        // в файле конфигурации приложения.
        public GeekBrainsWork1Context()
            : base("name=GeekBrainsWork1Context")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Position> Position { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());            
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    
}