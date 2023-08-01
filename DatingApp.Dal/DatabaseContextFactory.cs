using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatingApp.Dal
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Integrated Security=true;Initial Catalog=DatingApp";
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connectionString, 
                sqlOptions => sqlOptions.EnableRetryOnFailure());
            Console.WriteLine(connectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
