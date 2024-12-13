using Microsoft.EntityFrameworkCore;
using FunShield.Models;

namespace FunShield.Data
{
    public class FunShieldDbContext : DbContext
    {
        public FunShieldDbContext(DbContextOptions<FunShieldDbContext> options) : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<Session>? Sessions { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<StudentCourse>? StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CourseID)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentID, sc.CourseID });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentID);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseID);
        }
    }
}