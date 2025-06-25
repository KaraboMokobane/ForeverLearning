namespace ForeverLearning.Data
{
    public class EnrollmentService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IPrerequisiteChecker _prerequisiteChecker;
        private readonly INotificationService _notificationService;

        public EnrollmentService(
            IPaymentProcessor paymentProcessor,
            IPrerequisiteChecker prerequisiteChecker,
            INotificationService notificationService)
        {
            _paymentProcessor = paymentProcessor;
            _prerequisiteChecker = prerequisiteChecker;
            _notificationService = notificationService;
        }

        public EnrollmentResult Enroll(Student student, Course course)
        {
            // 1. Check if already enrolled
            if (student.Enrollments.Any(e => e.Course.Id == course.Id &&
                                           e.Status.Id != (int)EnrollmentStatusValue.Completed &&
                                           e.Status.Id != (int)EnrollmentStatusValue.Cancelled))
            {
                return EnrollmentResult.AlreadyEnrolled;
            }

            // 2. Check prerequisites
            if (!_prerequisiteChecker.HasRequiredPrerequisites(student, course))
            {
                return EnrollmentResult.PrerequisiteNotMet;
            }

            // 3. Process payment
            if (!_paymentProcessor.ProcessPayment(student, course.Price))
            {
                return EnrollmentResult.PaymentFailed;
            }

            // 4. Create enrollment
            var enrollment = new Enrollment(student, course);
            enrollment.Activate(); // Set status to Active

            // 5. Send confirmation
            _notificationService.SendEnrollmentConfirmation(student, course);

            return EnrollmentResult.Success;
        }
    }
}