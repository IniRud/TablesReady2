using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TablesReady.Data.Domain
{
    public partial class Restaurants_EmployeesContext : DbContext
    {
        public Restaurants_EmployeesContext()
        {
        }

        public Restaurants_EmployeesContext(DbContextOptions<Restaurants_EmployeesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressDetails> AddressDetails { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Phonebook> Phonebook { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=Restaurants_Employees;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressDetails>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("AddressID_PK");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Postal)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Prov)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNum)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AddressDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__AddressDe__Emplo__35BCFE0A");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.AddressDetails)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__AddressDe__Resta__34C8D9D1");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.EmaiId)
                    .HasName("EmailID_PK");

                entity.Property(e => e.EmaiId).HasColumnName("EmaiID");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Email__EmployeeI__2C3393D0");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Email__Restauran__2B3F6F97");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Middlename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Restau__276EDEB3");
            });

            modelBuilder.Entity<Phonebook>(entity =>
            {
                entity.HasKey(e => e.PhoneId)
                    .HasName("PhoneID_PK");

                entity.Property(e => e.PhoneId).HasColumnName("PhoneID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Phonebook)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Phonebook__Emplo__30F848ED");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Phonebook)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Phonebook__Resta__300424B4");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.RestaurantBusinessNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantSignUpDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
