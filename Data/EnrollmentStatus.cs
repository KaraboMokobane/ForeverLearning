//namespace ForeverLearning.Data
//{
//    public abstract class EnrollmentStatus
//    {
//        public int Id { get; protected set; }
//        public string Name { get; protected set; }
//        public string Description { get; protected set; }
//        public bool CanEnroll { get; protected set; }
//        public bool CanAccessContent { get; protected set; }

//        protected EnrollmentStatus(int id, string name, string description,
//                                bool canEnroll, bool canAccessContent)
//        {
//            Id = id;
//            Name = name;
//            Description = description;
//            CanEnroll = canEnroll;
//            CanAccessContent = canAccessContent;
//        }
//        public static readonly EnrollmentStatus Pending = new PendingStatus();
//        public static readonly EnrollmentStatus Active = new ActiveStatus();
//        public static readonly EnrollmentStatus Completed = new CompletedStatus();
//        public static readonly EnrollmentStatus Cancelled = new CancelledStatus();





//        public class PendingStatus : EnrollmentStatus
//        {
//            public PendingStatus() : base(0, "Pending", "Awaiting payment confirmation") { }
//        }

//        public class ActiveStatus : EnrollmentStatus
//        {
//            public ActiveStatus() : base(1, "Active", "Currently enrolled") { }
//        }

//        public class CompletedStatus : EnrollmentStatus
//        {
//            public CompletedStatus() : base(2, "Completed", "Course finished") { }
//        }

//        public class CancelledStatus : EnrollmentStatus
//        {
//            public CancelledStatus() : base(3, "Cancelled", "Enrollment cancelled") { }
//        }







//        // Domain behavior
//        public abstract void HandleStatusChange(Enrollment enrollment);

//        public virtual void BeforeStatusChange(Enrollment enrollment)
//        {
//            // Optional: Add pre-transition logic
//        }

//        // Called after status change completes
//        public virtual void AfterStatusChange(Enrollment enrollment)
//        {
//            // Optional: Add post-transition logic
//        }
//    }
//}


namespace ForeverLearning.Data
{

    public enum EnrollmentStatusValue
    {
        Pending = 0,
        Active = 1,
        Completed = 2,
        Cancelled = 3
    }

    public class EnrollmentStatus
    {
        public int Id { get; }
        public string Name { get; }

        protected EnrollmentStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static EnrollmentStatus FromValue(EnrollmentStatusValue value)
        {
            return value switch
            {
                EnrollmentStatusValue.Pending => new PendingStatus(),
                EnrollmentStatusValue.Active => new ActiveStatus(),
                EnrollmentStatusValue.Completed => new CompletedStatus(),
                EnrollmentStatusValue.Cancelled => new CancelledStatus(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    // Concrete status classes
    public class PendingStatus : EnrollmentStatus
    {
        public PendingStatus() : base((int)EnrollmentStatusValue.Pending, "Pending") { }
    }

    public class ActiveStatus : EnrollmentStatus
    {
        public ActiveStatus() : base((int)EnrollmentStatusValue.Active, "Active") { }
    }
}
