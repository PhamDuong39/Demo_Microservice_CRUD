﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Infragstructure.Data.Context;

#nullable disable

namespace Product.Infragstructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230927083028_InitProduct_V1")]
    partial class InitProduct_V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product.Domain.Entites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductSign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Product.Domain.Entites.TypeProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeProduct");
                });

            modelBuilder.Entity("Product.Domain.Entites.Product", b =>
                {
                    b.HasOne("Product.Domain.Entites.TypeProduct", "TypeProduct")
                        .WithMany("Products")
                        .HasForeignKey("TypeProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeProduct");
                });

            modelBuilder.Entity("Product.Domain.Entites.TypeProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
