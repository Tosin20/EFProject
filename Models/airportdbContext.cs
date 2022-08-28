
#nullable disable

using System;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace EFProject.Models
{
    public partial class airportdbContext : DbContext
    {
        public airportdbContext()
        {
        }

        public airportdbContext(DbContextOptions<airportdbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseExceptionProcessor();
                optionsBuilder.UseSqlServer("Server=.;Database=airportdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.Property(e => e.seatId)
                     .HasMaxLength(10)
                     .IsUnicode(false)
                     .IsFixedLength(true);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasNoKey();

                //entity.Property(e => e.payment).HasColumnType("decimal(22, 2)");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passenger");
                entity.HasKey(e => e.passId);
                entity.Property(e => e.passId).ValueGeneratedOnAdd();

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
