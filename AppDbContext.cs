using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DatabaseProject
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamMark> ExamMarks { get; set; }
        public DbSet<SectionCourse> SecCourses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships

            // Many-to-Many relationship between Student and Exam
            modelBuilder.Entity<ExamMark>()
                .HasKey(em => new { em.StudentId, em.SectionId, em.ExamId });

            modelBuilder.Entity<ExamMark>()
                .HasOne(em => em.Student)
                .WithMany(s => s.ExamMarks)
                .HasForeignKey(em => em.StudentId);

            modelBuilder.Entity<ExamMark>()
                .HasOne(em => em.Section)
                .WithMany(sec => sec.ExamMarks)
                .HasForeignKey(em => em.SectionId);

            modelBuilder.Entity<ExamMark>()
                .HasOne(em => em.Exam)
                .WithMany(exam => exam.ExamMarks)
                .HasForeignKey(em => em.ExamId);

            // Weak Entity (SecCourse) relationship with Section and Course
            modelBuilder.Entity<SectionCourse>()
                .HasKey(sc => new { sc.SectionId, sc.CourseId });

            modelBuilder.Entity<SectionCourse>()
                .HasOne(sc => sc.Section)
                .WithMany(sec => sec.SecCourses)
                .HasForeignKey(sc => sc.SectionId);

            modelBuilder.Entity<SectionCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.SecCourses)
                .HasForeignKey(sc => sc.CourseId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R25IHH5\\MSSQLSERVER044;Initial Catalog=DatabaseProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
