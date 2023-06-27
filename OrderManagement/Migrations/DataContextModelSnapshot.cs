﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.API.Data;

#nullable disable

namespace OrderManagement.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderManagement.Shared.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateBill")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Pass")
                        .HasColumnType("float");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeFlavorId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TypeFlavorId");

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

            modelBuilder.Entity("OrderManagement.Shared.Entities.Bill", b =>
                {
                    b.HasOne("OrderManagement.Shared.Entities.Order", "Order")
                        .WithMany("Bill")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderManagement.Shared.Entities.PaymentType", "PaymentType")
                        .WithMany("Bill")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Order", b =>
                {
                    b.HasOne("OrderManagement.Shared.Entities.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderManagement.Shared.Entities.Product", "Product")
                        .WithMany("Order")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Product", b =>
                {
                    b.HasOne("OrderManagement.Shared.Entities.TypeFlavor", "TypeFlavor")
                        .WithMany("Product")
                        .HasForeignKey("TypeFlavorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeFlavor");
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

            modelBuilder.Entity("OrderManagement.Shared.Entities.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Order", b =>
                {
                    b.Navigation("Bill");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.PaymentType", b =>
                {
                    b.Navigation("Bill");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.Product", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.TypeFlavor", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderManagement.Shared.Entities.TypeProduct", b =>
                {
                    b.Navigation("TypeFlavors");
                });
#pragma warning restore 612, 618
        }
    }
}
