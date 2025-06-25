namespace ForeverLearning.Data
{
    public abstract class User
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DateJoined { get; protected set; } = DateTime.UtcNow;


        protected User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public abstract string GetDashboard();
    }

    public class Student : User
    {
        public List<EnrollmentService> Enrollments { get; } = new();
        public Student(string name, string email) : base(name, email) { }
        public override string GetDashboard() => "Student Dashboard: Course, Progress";

    }

    public class Instructor : User
    {
        public List<Course> AuthoredCourses { get; } = new();
        public Instructor(string name, string email):base(name, email) { }
        public override string GetDashboard() => "Ïnstructor Dashboard: Analytics, Students";
    }

}
