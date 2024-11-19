using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure.Data
{
    //Para criar migrations: dotnet ef migrations add InitialCreate --project Infrastructure --startup-project WebAPI
    //Para o banco: dotnet ef database update --project Infrastructure --startup-project WebApi
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
