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

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(a => a.AccountNavigation)
                .WithOne(u => u.UserNavigation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_Account");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(a => a.UserNavigation)
                .WithOne(u => u.AccountNavigation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_Account");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasOne(p => p.AccountNavigation)
                .WithMany(a => a.PhotoNavigation)
                .HasForeignKey(k => k.AccountId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Photos_Accounts");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasMany(m => m.FromAccount)
                .WithMany(a => a.LikeNavigation)
                .UsingEntity("Likes_AccountsFrom");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasMany(m => m.ToAccount)
                .WithMany(a => a.LikeNavigation)
                .UsingEntity("Likes_AccountsTo");
            });
        }
    }
}
