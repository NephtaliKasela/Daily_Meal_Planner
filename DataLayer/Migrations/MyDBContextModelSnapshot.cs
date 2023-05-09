﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessLayer.MealTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MealTime");
                });

            modelBuilder.Entity("BusinessLayer.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbs")
                        .HasColumnType("float");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<double>("Gramms")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Calories = 225.0,
                            Carbs = 0.5,
                            CategoryName = "Алкоголь",
                            Fats = 0.0,
                            Gramms = 100.0,
                            Name = "Бренди 40% алкоголя",
                            Protein = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Calories = 158.0,
                            Carbs = 15.9,
                            CategoryName = "Алкоголь",
                            Fats = 0.0,
                            Gramms = 100.0,
                            Name = "Вермут 13% алкоголя",
                            Protein = 0.0
                        },
                        new
                        {
                            Id = 3,
                            Calories = 78.0,
                            Carbs = 4.5,
                            CategoryName = "Алкоголь",
                            Fats = 0.0,
                            Gramms = 100.0,
                            Name = "Вино белое 10% алкоголя",
                            Protein = 0.0
                        },
                        new
                        {
                            Id = 4,
                            Calories = 223.0,
                            Carbs = 23.199999999999999,
                            CategoryName = "Готовые блюда",
                            Fats = 10.0,
                            Gramms = 100.0,
                            Name = "Беляши",
                            Protein = 11.0
                        },
                        new
                        {
                            Id = 5,
                            Calories = 640.0,
                            Carbs = 55.200000000000003,
                            CategoryName = "Готовые блюда",
                            Fats = 33.100000000000001,
                            Gramms = 100.0,
                            Name = "Блинчики с творогом и сметаной",
                            Protein = 25.800000000000001
                        },
                        new
                        {
                            Id = 6,
                            Calories = 23.0,
                            Carbs = 1.1000000000000001,
                            CategoryName = "Грибы",
                            Fats = 1.7,
                            Gramms = 100.0,
                            Name = "Белые грибы",
                            Protein = 3.7000000000000002
                        },
                        new
                        {
                            Id = 7,
                            Calories = 152.0,
                            Carbs = 7.5999999999999996,
                            CategoryName = "Грибы",
                            Fats = 4.7999999999999998,
                            Gramms = 100.0,
                            Name = "Белые грибы сушеные",
                            Protein = 20.100000000000001
                        });
                });

            modelBuilder.Entity("BusinessLayer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusinessLayer.UserProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbs")
                        .HasColumnType("float");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<double>("Gramms")
                        .HasColumnType("float");

                    b.Property<string>("Mealtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProducts");
                });

            modelBuilder.Entity("BusinessLayer.MealTime", b =>
                {
                    b.HasOne("BusinessLayer.User", null)
                        .WithMany("Mealtimes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BusinessLayer.User", b =>
                {
                    b.Navigation("Mealtimes");
                });
#pragma warning restore 612, 618
        }
    }
}
