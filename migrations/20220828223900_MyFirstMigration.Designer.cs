// <auto-generated />
using System;
using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFProject.Migrations
{
    [DbContext(typeof(airportdbContext))]
    [Migration("20220828223900_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFProject.Models.Passenger", b =>
                {
                    b.Property<int>("passId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength(true);

                    b.HasKey("passId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("EFProject.Models.Payment", b =>
                {
                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("passId")
                        .HasColumnType("int");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EFProject.Models.Seat", b =>
                {
                    b.Property<int>("seatId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .IsFixedLength(true)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("passId")
                        .HasColumnType("int");

                    b.Property<int>("purchaseId")
                        .HasColumnType("int");

                    b.HasKey("seatId");

                    b.ToTable("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
