namespace ForeverLearning.Data
{
    public class CourseFactory
    {
        public Course CreateCourse(string title, string descripction, Instructor author, CourseCategory category)
        {
            ValidateCourseDetails(title, descripction, author);
            return new Course(title, descripction, author)
            {
                Category = category,
                CreationDate = DateTime.UtcNow
            };
        }

        public void ValidateCourseDetails(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title required");
            if (description.Length < 50)
                throw new ArgumentException("Desription too short");
        }
    }
}
