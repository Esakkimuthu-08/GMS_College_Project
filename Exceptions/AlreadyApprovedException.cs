using Grievance_Management_System.Constants;

namespace Grievence_Management_System_Project.Exceptions
{
    public class AlreadyApprovedException : AppException
    {
        public AlreadyApprovedException()
            : base(ErrorConstant.AlreadyApproved, 400)
        {
        }
    }
}
