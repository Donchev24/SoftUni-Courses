using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using static P01_StudentSystem.Data.Common.ApplicationCommonConfiguration;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        protected StudentSystemContext()
        {
        }
        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }

        


    }
}
