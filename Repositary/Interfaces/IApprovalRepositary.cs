using Grievance_Management_System.Auth;
using Grievance_Management_System.Model;
using Grievance_Management_System.Request;

namespace Grievence_Management_System_Project.Repositary.Interfaces
{
    public interface IApprovalRepositary
    {
        Task<StaffSignUp> GetStaffRequestId(int id);

        void UpdateStaffRequest(StaffSignUp staff);

        Task AddUser(User user);

        Task AddStaff(Staff staff);
        Task Save();
    }
}
