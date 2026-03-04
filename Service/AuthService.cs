using Grievance_Management_System.Auth;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;

namespace Grievence_Management_System_Project.Service
{
    public class AuthService(IAuthRepositary authRepositary) : IAuthService
    {
        public async Task StaffSignUp(StaffSignUpRequest staffSignUpRequest)
        {
            StaffSignUp staffSignUp = new StaffSignUp()
            {
                Name = staffSignUpRequest.Name,
                Email = staffSignUpRequest.Email,
                PasswordHash = staffSignUpRequest.PasswordHash,
                IsApproved = false
            };
           await authRepositary.StaffSignUp(staffSignUp);
        }
        public async Task<List<StaffSignUp>> GetAllStaffSignUp()
        {
            return await authRepositary.GetAllStaffRequest();
        }
    }
}
