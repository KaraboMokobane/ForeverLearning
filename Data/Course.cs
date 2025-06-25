using Microsoft.Identity.Client;
using System.Reflection;

namespace ForeverLearning.Data
{
    public class Course
    {
        public int Id {  get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Instructor Author {  get; private set; }
        public List<Module> Modules { get; } = new();
        public List<EnrollmentService> Enrollments { get; } = new();

        public Course(string title, string description, Instructor author)
        {
            Title = title;
            Description = description;
            Author = author;
            author.AuthoredCourses.Add(this);
        }

        public void AddModule(Module module) => Modules.Add(module);
    }

    public class EnrollmentService
    {
        public Student Student { get; }
        public Course Course { get; }
        public DateTime EnrollmentDate { get; }
        public EnrollmentStatus Status { get; private set; }

        public EnrollmentService(Student student, Course course)
        {
            Student = student;
            Course = course;
            EnrollmentDate = DateTime.UtcNow;
            Status = EnrollmentStatus.Active;
            student.Enrollments.Add(this);
            course.Enrollments.Add(this);
        }

        public void Complete() => Status = EnrollmentStatus.Completed;
    }
}
