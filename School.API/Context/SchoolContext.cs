using Microsoft.EntityFrameworkCore;
using School.API.Entities;

namespace School.API.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source='localhost, 1433'; User ID=sa; Database=InternalTalent; Password=Bruno@123; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
               e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Entity<Course>()
                        .HasMany(c => c.Students)
                        .WithOne(c => c.Course)
                        .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Course>()
                        .HasIndex(c => c.Name)
                        .IsUnique();

            modelBuilder.Entity<Student>()
                        .HasIndex(c => c.Name)
                        .IsUnique();
        }
    }
}
