﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pantry.Data;

namespace Pantry.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20201028005209_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pantry.Models.Categories", b =>
                {
                    b.Property<Guid>("CategoriesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriesID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Pantry.Models.PantryItems", b =>
                {
                    b.Property<Guid>("PantryItemsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryCategoriesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PantryItemsID");

                    b.HasIndex("CategoryCategoriesID");

                    b.ToTable("PantryItems");
                });

            modelBuilder.Entity("Pantry.Models.PantryItems", b =>
                {
                    b.HasOne("Pantry.Models.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryCategoriesID");
                });
#pragma warning restore 612, 618
        }
    }
}