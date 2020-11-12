﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spango_Kitchen.Model;

namespace Spango_Kitchen.Migrations
{
    [DbContext(typeof(Spago_Context))]
    [Migration("20201112153058_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Spango_Kitchen.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.CookingTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CookingTime");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Cousine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CousineName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cousine");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CookingTimeId")
                        .HasColumnType("int");

                    b.Property<int>("CousineId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CookingTimeId");

                    b.HasIndex("CousineId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.DishIngredientsDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("DishIngredientsDetails");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Dish", b =>
                {
                    b.HasOne("Spango_Kitchen.Model.Category", "Category")
                        .WithMany("Dishes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spango_Kitchen.Model.CookingTime", "CookingTime")
                        .WithMany("Dish")
                        .HasForeignKey("CookingTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spango_Kitchen.Model.Cousine", "Cousine")
                        .WithMany("Dish")
                        .HasForeignKey("CousineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CookingTime");

                    b.Navigation("Cousine");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.DishIngredientsDetails", b =>
                {
                    b.HasOne("Spango_Kitchen.Model.Dish", "Dish")
                        .WithMany("DishIngredientsDetails")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spango_Kitchen.Model.Ingredient", "Ingredients")
                        .WithMany("DishIngredientsDetails")
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Category", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.CookingTime", b =>
                {
                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Cousine", b =>
                {
                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Dish", b =>
                {
                    b.Navigation("DishIngredientsDetails");
                });

            modelBuilder.Entity("Spango_Kitchen.Model.Ingredient", b =>
                {
                    b.Navigation("DishIngredientsDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
