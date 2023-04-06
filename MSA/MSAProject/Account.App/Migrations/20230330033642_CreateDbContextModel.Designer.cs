﻿// <auto-generated />
using System;
using Account.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Account.App.Migrations
{
    [DbContext(typeof(DbContextModel))]
    [Migration("20230330033642_CreateDbContextModel")]
    partial class CreateDbContextModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Account.Domain.AggregateModels.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<decimal>("CustomerWallet")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("QuantitySold")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Revenue", b =>
                {
                    b.Property<int>("RevenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RevenueId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("OrderId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("Total")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("RevenueId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Revenue");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Order", b =>
                {
                    b.HasOne("Account.Domain.AggregateModels.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Account.Domain.AggregateModels.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Revenue", b =>
                {
                    b.HasOne("Account.Domain.AggregateModels.Order", "Order")
                        .WithOne("Revenue")
                        .HasForeignKey("Account.Domain.AggregateModels.Revenue", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Order", b =>
                {
                    b.Navigation("Revenue")
                        .IsRequired();
                });

            modelBuilder.Entity("Account.Domain.AggregateModels.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
