using Microsoft.EntityFrameworkCore;

namespace ForeverLearning.Data
{
    public class LearningPlatformContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPT inheritance
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");

            // Configure relationships
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany(i => i.AuthoredCourses)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
