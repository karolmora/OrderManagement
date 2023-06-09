﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.API.Data;

#nullable disable

namespace OrderManagement.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230609024125_DeleteFieldSize")]
    partial class DeleteFieldSize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderManagement.Shared.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeProductId")
                        .HasColumnType("int");

                    b.Property<double>("ValueProduct")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TypeProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.TypeFlavor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeProductId");

                    b.ToTable("TypeFlavor");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.TypeProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeProduct");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Product", b =>
                {
                    b.HasOne("OrderManagement.Shared.Entities.TypeProduct", "TypeProduct")
                        .WithMany("Product")
                        .HasForeignKey("TypeProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeProduct");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.TypeFlavor", b =>
                {
                    b.HasOne("OrderManagement.Shared.Entities.TypeProduct", "TypeProduct")
                        .WithMany("TypeFlavors")
                        .HasForeignKey("TypeProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeProduct");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.TypeProduct", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("TypeFlavors");
                });
#pragma warning restore 612, 618
        }
    }
}