namespace ForeverLearning.Data
{
    public interface IContentModerationStrategy
    {
        bool ApproveContent(Course course);
    }
    public class StrictModeration : IContentModerationStrategy
    {
        public bool ApproveContent(Course course)
        {
            return !course.Description.Contains("sensitive content")
                   && course.Modules.Count >= 3;
        }
    }

    public class AdminService
    {
        private readonly IContentModerationStrategy _moderationStrategy;

        public AdminService(IContentModerationStrategy moderationStrategy)
        {
            _moderationStrategy = moderationStrategy;
        }

        public bool ApproveCourse(Course course)
        {
            return _moderationStrategy.ApproveContent(course);
        }
    }
}
