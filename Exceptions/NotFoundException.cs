using Grievance_Management_System.Constants;

namespace Grievence_Management_System_Project.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException()
            : base(ErrorConstant.NotFound, 404) { }
    }
}
