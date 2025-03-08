

using lab2_Fluent_API.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Context
{
    public class Lab2Context : DbContext
    {
        DbSet<Student> Students {  get; set; }
        DbSet<Teacher> Teatchers { get; set; }
        DbSet<Courses> Courses { get; set; }
        DbSet<Attendances> Attendances { get; set; }
        DbSet<Enrollments> Enrollments { get; set; }
        DbSet<Classrooms> classrooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                  .UseSqlServer("Data source = .; Initial catalog = DB_FluentAPI; Integrated security= true; trustservercertificate = true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student table
            modelBuilder.Entity<Student>().HasKey(S => S.StudentId);
            modelBuilder.Entity<Student>().Property(S => S.Name).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Student>().Property(S => S.Email).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Student>().Property(S => S.Phone).HasColumnType("nvarchar(20)").IsRequired();

            // Cours Table
            modelBuilder.Entity<Courses>().HasKey(C => C.CourseId);
            modelBuilder.Entity<Courses>().Property(C => C.Name).HasColumnType("nvarchar(50)").IsRequired();


            // Teacher Table
            modelBuilder.Entity<Teacher>().HasKey(T => T.TeacherId);
            modelBuilder.Entity<Teacher>().Property(T => T.Subject)
                .HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<Teacher>().Property(t => t.Email).HasColumnType("nvarchar(50)").IsRequired();

            //Enrollment 

            modelBuilder.Entity<Enrollments>()
                .HasKey(e => new { e.StudentId, e.CoursId });
            modelBuilder.Entity<Enrollments>()
                .Property(e => e.Grade).IsRequired(true);

            //Attendenc 

            modelBuilder.Entity<Attendances>()
                .HasKey(a => a.AttendanceId);


            //ClassRoom 
            modelBuilder.Entity<Classrooms>()
                .HasKey(cl =>cl.ClassroomId);
            modelBuilder.Entity<Classrooms>()
                .Property(C => C.Name)
                .HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Classrooms>()
                .Property(e => e.Capacity).IsRequired(true);

            // Realashion
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teatcher)
                .HasForeignKey(c => c.TeacherID);

            modelBuilder.Entity<Classrooms>()
                .HasMany(c => c.Courses)
                .WithOne(cl => cl.Classrooms)
                .HasForeignKey(cl => cl.ClassroomID);


            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Attendances)
                .WithOne(a=> a.Courses)
                .HasForeignKey(a=>a.CoursId);

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Courses)
                .HasForeignKey(e=>e.CoursId);


            modelBuilder.Entity<Student>()
               .HasMany(S => S.Attendances)
               .WithOne(a  =>a.Student)
               .HasForeignKey(a =>a.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(S => S.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);






            base.OnModelCreating(modelBuilder);


        }

    }
}
