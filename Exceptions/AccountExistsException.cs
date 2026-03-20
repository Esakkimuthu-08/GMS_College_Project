using Grievance_Management_System.Constants;

namespace Grievence_Management_System_Project.Exceptions
{
    public class AccountExistsException : AppException
    {
        public AccountExistsException()
            : base(ErrorConstant.AccountExist, 409) { }
    }
}
