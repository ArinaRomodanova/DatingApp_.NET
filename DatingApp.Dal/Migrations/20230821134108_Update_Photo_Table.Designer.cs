﻿// <auto-generated />
using DatingApp.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatingApp.Dal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230821134108_Update_Photo_Table")]
    partial class Update_Photo_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatingApp.Dal.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DatingApp.Dal.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("DatingApp.Dal.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DatingApp.Dal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Likes_AccountsFrom", b =>
                {
                    b.Property<int>("LikeNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("int");

                    b.HasKey("LikeNavigationId", "ToAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("Likes_AccountsFrom");
                });

            modelBuilder.Entity("Likes_AccountsTo", b =>
                {
                    b.Property<int>("LikeNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("int");

                    b.HasKey("LikeNavigationId", "ToAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("Likes_AccountsTo");
                });

            modelBuilder.Entity("DatingApp.Dal.Models.Photo", b =>
                {
                    b.HasOne("DatingApp.Dal.Models.Account", "AccountNavigation")
                        .WithMany("PhotoNavigation")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Photos_Accounts");

                    b.Navigation("AccountNavigation");
                });

            modelBuilder.Entity("DatingApp.Dal.Models.User", b =>
                {
                    b.HasOne("DatingApp.Dal.Models.Account", "AccountNavigation")
                        .WithOne("UserNavigation")
                        .HasForeignKey("DatingApp.Dal.Models.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Account");

                    b.Navigation("AccountNavigation");
                });

            modelBuilder.Entity("Likes_AccountsFrom", b =>
                {
                    b.HasOne("DatingApp.Dal.Models.Like", null)
                        .WithMany()
                        .HasForeignKey("LikeNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatingApp.Dal.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Likes_AccountsTo", b =>
                {
                    b.HasOne("DatingApp.Dal.Models.Like", null)
                        .WithMany()
                        .HasForeignKey("LikeNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatingApp.Dal.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Dal.Models.Account", b =>
                {
                    b.Navigation("PhotoNavigation");

                    b.Navigation("UserNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
