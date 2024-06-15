﻿// <auto-generated />
using System;
using Lab13S13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab13S13.Migrations
{
    [DbContext(typeof(DbSemana13))]
    [Migration("20240615170418_v1-crear base de datos")]
    partial class v1crearbasededatos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab13S13.Models.Customers", b =>
                {
                    b.Property<int>("CustomersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomersID"));

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomersID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab13S13.Models.Details", b =>
                {
                    b.Property<int>("DetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailsID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("InvoicesID")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.HasKey("DetailsID");

                    b.HasIndex("InvoicesID");

                    b.HasIndex("ProductsID");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("Lab13S13.Models.Invoices", b =>
                {
                    b.Property<int>("InvoicesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoicesID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoicesNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.HasKey("InvoicesID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Lab13S13.Models.Products", b =>
                {
                    b.Property<int>("ProductsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductsID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductsID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Lab13S13.Models.Details", b =>
                {
                    b.HasOne("Lab13S13.Models.Invoices", "Invoices")
                        .WithMany()
                        .HasForeignKey("InvoicesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab13S13.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
