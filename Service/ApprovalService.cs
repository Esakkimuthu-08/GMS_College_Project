using Grievance_Management_System.Auth;
using Grievance_Management_System.Constants;
using Grievance_Management_System.Enum;
using Grievance_Management_System.Model;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;

namespace Grievence_Management_System_Project.Service
{
    public class ApprovalService(IApprovalRepositary approvalRepositary) : IApprovalService
    {
        public async Task ApproveStaff(ApproveStaffDto approveStaffDto)
        {
            StaffSignUp staffRequest = await approvalRepositary.GetStaffRequestId(approveStaffDto.SignupRequestId);

            if (staffRequest == null)
            {
                throw new Exception(ErrorConstant.NotFound);
            }

            if (staffRequest.IsApproved)
            {
                throw new Exception("Staff already approved");
            }

            staffRequest.IsApproved = true;

            User user = new User()
            {
                Email = staffRequest.Email,
                PasswordHash = staffRequest.PasswordHash,
                Role = RoleEnum.Staff,
                IsActive = true
            };

            Staff staff = new Staff
            {
                Name = staffRequest.Name,
                Email = staffRequest.Email,
                Role = approveStaffDto.Role,
                StaffCode = approveStaffDto.StaffCode,
                PhoneNumber = approveStaffDto.PhoneNumber
            };

            await approvalRepositary.AddStaff(staff);
            approvalRepositary.UpdateStaffRequest(staffRequest);
            await approvalRepositary.AddUser(user);
            await approvalRepositary.Save();
        } 
    }
}
