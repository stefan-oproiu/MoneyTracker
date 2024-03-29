﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220320154446_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.MoneyCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MoneyCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "shopping_cart",
                            Name = "Shopping",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Icon = "restaurant",
                            Name = "Food",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Icon = "health_and_safety",
                            Name = "Health",
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Icon = "school",
                            Name = "Education",
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            Icon = "receipt_long",
                            Name = "Bills & Utilities",
                            Type = 0
                        },
                        new
                        {
                            Id = 6,
                            Icon = "commute",
                            Name = "Transportation",
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            Icon = "sports_esports",
                            Name = "Entertainment",
                            Type = 0
                        },
                        new
                        {
                            Id = 8,
                            Icon = "volunteer_activism",
                            Name = "Donations",
                            Type = 0
                        },
                        new
                        {
                            Id = 9,
                            Icon = "family_restroom",
                            Name = "Family",
                            Type = 0
                        },
                        new
                        {
                            Id = 10,
                            Icon = "public",
                            Name = "Other",
                            Type = 0
                        },
                        new
                        {
                            Id = 11,
                            Icon = "payments",
                            Name = "Salary",
                            Type = 1
                        },
                        new
                        {
                            Id = 12,
                            Icon = "sell",
                            Name = "Sale",
                            Type = 1
                        },
                        new
                        {
                            Id = 13,
                            Icon = "currency_exchange",
                            Name = "Trading",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.MoneyEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MoneyCategoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Value")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("MoneyCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("MoneyEntries");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MonthlyBudget")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.MoneyEntry", b =>
                {
                    b.HasOne("Domain.Entities.MoneyCategory", "MoneyCategory")
                        .WithMany()
                        .HasForeignKey("MoneyCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("MoneyEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MoneyCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("MoneyEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
