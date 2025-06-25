namespace ForeverLearning.Data
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(Student student, decimal amount);
    }

    public interface IPrerequisiteChecker
    {
        bool HasRequiredPrerequisites(Student student, Course course);
    }

    public interface INotificationService
    {
        void SendEnrollmentConfirmation(Student student, Course course);
    }
}
