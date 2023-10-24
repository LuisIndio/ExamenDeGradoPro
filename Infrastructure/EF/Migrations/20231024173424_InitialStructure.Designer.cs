﻿// <auto-generated />
using System;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20231024173424_InitialStructure")]
    partial class InitialStructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EF.ReadModel.AccountReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<decimal>("Balance")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal")
                        .HasColumnName("balance");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.CategoryReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoryId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.TransactionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("transactionId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<decimal>("Amount")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal")
                        .HasColumnName("amount");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoryId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.TransferReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("transferId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<Guid>("AccountId2")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId2");

                    b.Property<decimal>("Amount")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Transfer", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.UserReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.AccountReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModel.UserReadModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.CategoryReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModel.UserReadModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.TransactionReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModel.AccountReadModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.ReadModel.CategoryReadModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.ReadModel.UserReadModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.TransferReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModel.AccountReadModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.ReadModel.UserReadModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
