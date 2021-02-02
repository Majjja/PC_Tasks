using ExamRecording.Models.Enums;
using ExamRecording.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExamRecording.DataAccess.Context
{
    public class ExamRecordingDbContext : DbContext
    {
        public ExamRecordingDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ExamActivity> ExamActivities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<FacultyRoom> FacultyRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamActivity>()
                .HasKey(ea => new { ea.StudentId, ea.CourseId, ea.FacultyRoomId });

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Courses)
                .WithOne(c => c.Professor)
                .HasForeignKey(c => c.ProfessorId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.ExamActivities)
                .WithOne(ea => ea.Student)
                .HasForeignKey(ea => ea.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.ExamActivities)
                .WithOne(ea => ea.Course)
                .HasForeignKey(ea => ea.CourseId);

            modelBuilder.Entity<FacultyRoom>()
                .HasMany(fr => fr.ExamActivities)
                .WithOne(ea => ea.FacultyRoom)
                .HasForeignKey(ea => ea.FacultyRoomId);

            Seed(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfEnrolling = DateTime.Now },
                new Student { Id = 2, FirstName = "Jony", LastName = "Jonies", DateOfEnrolling = DateTime.Now },
                new Student { Id = 3, FirstName = "Mili", LastName = "Miee", DateOfEnrolling = DateTime.Now },
                new Student { Id = 4, FirstName = "Richi", LastName = "Rich", DateOfEnrolling = DateTime.Now },
                new Student { Id = 5, FirstName = "Lilly", LastName = "Lee", DateOfEnrolling = DateTime.Now },
                new Student { Id = 6, FirstName = "Mili", LastName = "Mo", DateOfEnrolling = DateTime.Now },
                new Student { Id = 7, FirstName = "Lolita", LastName = "Lolis", DateOfEnrolling = DateTime.Now });

            modelBuilder.Entity<Professor>()
                .HasData(
                new Professor { Id = 1, FirstName = "Billy", LastName = "Bils" },
                new Professor { Id = 2, FirstName = "Mendy", LastName = "Moore" },
                new Professor { Id = 3, FirstName = "Jeny", LastName = "Jens" });

            modelBuilder.Entity<Course>()
                .HasData(
                new Course { Id = 1, Name = "Programming", Code = 33, ProfessorId = 1 },
                new Course { Id = 2, Name = "Digital Marketing", Code = 22, ProfessorId = 2 },
                new Course { Id = 3, Name = "Information Security Management System", Code = 12, ProfessorId = 2 },
                new Course { Id = 4, Name = "Design", Code = 15, ProfessorId = 1 },
                new Course { Id = 5, Name = "Software Testing", Code = 17, ProfessorId = 1 },
                new Course { Id = 6, Name = "Computer Networks", Code = 11, ProfessorId = 3 },
                new Course { Id = 7, Name = "Data Science", Code = 25, ProfessorId = 3 });

            modelBuilder.Entity<FacultyRoom>()
                .HasData(
                new FacultyRoom { Id = 1, Name = "Room1", Location = "Location1", NumberOfSeats = 15, FacultyRoomType = FacultyRoomType.Laboratory },
                new FacultyRoom { Id = 2, Name = "Room2", Location = "Location2", NumberOfSeats = 25, FacultyRoomType = FacultyRoomType.Classroom },
                new FacultyRoom { Id = 3, Name = "Room3", Location = "Location3", NumberOfSeats = 30, FacultyRoomType = FacultyRoomType.Classroom });

            modelBuilder.Entity<ExamActivity>()
                .HasData(
                new ExamActivity { Id = 1, StudentId = 1, CourseId = 1, FacultyRoomId = 1, DateOfExam = DateTime.Now, StudentGrade = 10 },
                new ExamActivity { Id = 2, StudentId = 2, CourseId = 1, FacultyRoomId = 1, DateOfExam = DateTime.Now, StudentGrade = 8 },
                new ExamActivity { Id = 3, StudentId = 3, CourseId = 1, FacultyRoomId = 1, DateOfExam = DateTime.Now, StudentGrade = 8 },
                new ExamActivity { Id = 4, StudentId = 4, CourseId = 4, FacultyRoomId = 2, DateOfExam = DateTime.Now, StudentGrade = 7 },
                new ExamActivity { Id = 5, StudentId = 5, CourseId = 4, FacultyRoomId = 2, DateOfExam = DateTime.Now, StudentGrade = 8 },
                new ExamActivity { Id = 6, StudentId = 6, CourseId = 5, FacultyRoomId = 3, DateOfExam = DateTime.Now, StudentGrade = 9 },
                new ExamActivity { Id = 7, StudentId = 7, CourseId = 5, FacultyRoomId = 3, DateOfExam = DateTime.Now, StudentGrade = 10 });
        }
    }
}
