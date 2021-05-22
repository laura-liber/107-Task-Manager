using Microsoft.EntityFrameworkCore;

namespace taskManager.Models 
{
    public class DataContext : DbContext
    {

        /*
            Run migrations everytime something changes on the models

            - dotnet ef migrations add <someName>
            - dotnet ef database update
         */
        public DataContext(DbContextOptions<DataContext> conInfo) : base(conInfo)
        {

        }

        //which of your models should become tables inside the DataBase

        public DbSet<Task> Tasks {get; set;}
    }
}
