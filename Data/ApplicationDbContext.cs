using Microsoft.EntityFrameworkCore;
using Campus_Placement_Management_System.Models;

namespace Campus_Placement_Management_System.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<PlacementDrive> PlacementDrives { get; set; }

    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Decimal Precision
        modelBuilder.Entity<Student>()
            .Property(s => s.CGPA)
            .HasPrecision(3, 2);

        modelBuilder.Entity<Company>()
            .Property(c => c.Package)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Company>()
            .Property(c => c.MinCGPA)
            .HasPrecision(3, 2);

        // ==========================
        // Relationships
        // ==========================

        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PlacementDrive>()
            .HasOne(p => p.Company)
            .WithMany()
            .HasForeignKey(p => p.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Student)
            .WithMany()
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.PlacementDrive)
            .WithMany()
            .HasForeignKey(a => a.DriveId)
            .OnDelete(DeleteBehavior.Cascade);

        // ==========================
        // Seed Roles
        // ==========================

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                RoleId = 1,
                RoleName = "Admin"
            },
            new Role
            {
                RoleId = 2,
                RoleName = "Student"
            },
            new Role
            {
                RoleId = 3,
                RoleName = "Company"
            }
        );
    }
}