using Grievance_Management_System.Auth;
using Grievance_Management_System.Request;

namespace Grievence_Management_System_Project.Repositary.Interfaces
{
    public interface IAuthRepositary
    {
         Task StaffSignUp(StaffSignUp staffSignUp);
        Task<List<StaffSignUp>> GetAllStaffRequest();
    }
}
