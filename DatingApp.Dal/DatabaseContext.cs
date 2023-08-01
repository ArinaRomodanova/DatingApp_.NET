using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage;
using DatingApp.Dal.Models;

namespace DatingApp.Dal
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        DbSet<User> Users { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
