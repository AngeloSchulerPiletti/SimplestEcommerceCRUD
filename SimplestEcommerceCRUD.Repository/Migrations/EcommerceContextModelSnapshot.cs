﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimplestEcommerceCRUD.Repository.Database.Context;

#nullable disable

namespace SimplestEcommerceCRUD.Repository.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Costumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.ItemPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("ItemPurchases");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CostumerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CostumerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.ItemPurchase", b =>
                {
                    b.HasOne("SimplestEcommerceCRUD.Domain.Entities.Product", "Product")
                        .WithMany("ItemPurchases")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimplestEcommerceCRUD.Domain.Entities.Purchase", "Purchase")
                        .WithMany("ItemPurchases")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Purchase", b =>
                {
                    b.HasOne("SimplestEcommerceCRUD.Domain.Entities.Costumer", "Costumer")
                        .WithMany("Purchases")
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Costumer");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Costumer", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Product", b =>
                {
                    b.Navigation("ItemPurchases");
                });

            modelBuilder.Entity("SimplestEcommerceCRUD.Domain.Entities.Purchase", b =>
                {
                    b.Navigation("ItemPurchases");
                });
#pragma warning restore 612, 618
        }
    }
}
