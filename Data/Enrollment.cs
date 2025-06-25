namespace ForeverLearning.Data
{
    // Models/Enrollment.cs
        public class Enrollment
        {
            public int Id { get; private set; }
            public Student Student { get; private set; }
            public Course Course { get; private set; }
            public DateTime EnrollmentDate { get; private set; }
            public EnrollmentStatus Status { get; private set; }

            // For EF Core
            private Enrollment() { }

            public Enrollment(Student student, Course course)
            {
                Student = student;
                Course = course;
                EnrollmentDate = DateTime.UtcNow;
                Status = EnrollmentStatus.FromValue(EnrollmentStatusValue.Pending);
            }

            public void Activate()
            {
                Status = EnrollmentStatus.FromValue(EnrollmentStatusValue.Active);
            }
        }
    }
