using System;
using Microsoft.EntityFrameworkCore;


namespace Task_2
{
    public class EmployeeInfoContext : DbContext
    {
        public EmployeeInfoContext()
        {
        }

        public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<Training> training { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb; Database=EmployeeInfo; Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "UQ__Employee__A9D10534240B4149")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<EmployeeTraining>(entity =>
            {
                entity.HasKey(e => new {e.EmployeeId, e.TrainingId})
                    .HasName("PK_dbo_EmployeeTraining");

                entity.ToTable("EmployeeTraining");

                entity.HasIndex(e => e.EmployeeId, "IX_dbo_EmployeeTraining_dbo_Employee");

                entity.HasIndex(e => e.TrainingId, "IX_dbo_EmployeeTraining_dbo_Training");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTrainings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo_EmployeeTraining_dbo_Employee");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.EmployeeTrainings)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_dbo_EmployeeTraining_dbo_Training");
            });

            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.ToTable("Vacation");

                entity.HasIndex(e => e.EmployeeId, "IX_dbo_Vacation_dbo_Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Vacations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo_Vacation_dbo_Employee");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("Training");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

        }
    }
}