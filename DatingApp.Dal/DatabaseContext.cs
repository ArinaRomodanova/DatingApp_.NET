using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage;

namespace DatingApp.Dal
{
    public class DatabaseContext: DbContext
    {
        public static IConfiguration GetConfiguration() =>
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public DatabaseContext(IConfiguration configuration)
        {

            var optionsBuider = new DbContextOptionsBuilder<DatabaseContext>();
            var connectionString = configuration.GetConnectionString("DatingApp");
            optionsBuider.UseSqlServer(connectionString);
        }
    }
}
