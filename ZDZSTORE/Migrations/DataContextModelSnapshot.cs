﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ZDZSTORE.database;

#nullable disable

namespace ZDZSTORE.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ZDZSTORE.Product.Model.ProductModel", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ZDZSTORE.Sale.Model.SaleModel", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<long>("customerCPF")
                        .HasColumnType("bigint");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.HasKey("id");

                    b.HasIndex("userID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("ZDZSTORE.User.Model.UserModel", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZDZSTORE.Sale.Model.SaleModel", b =>
                {
                    b.HasOne("ZDZSTORE.User.Model.UserModel", "user")
                        .WithMany("sales")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ZDZSTORE.User.Model.UserModel", b =>
                {
                    b.Navigation("sales");
                });
#pragma warning restore 612, 618
        }
    }
}
