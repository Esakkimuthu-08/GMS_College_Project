using Grievance_Management_System.Auth;
using Grievance_Management_System.Constants;
using Grievance_Management_System.Enum;
using Grievance_Management_System.Model;
using Grievance_Management_System.Model.Auth;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Model;
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

        public async Task ApproveStudent(ApproveStudentDto approveStudentDto)
        {
            StudentSignUp signUpRequest = await approvalRepositary
                .GetStudentRequestId(approveStudentDto.StudentSignUpId);

            if (signUpRequest == null)
            {
                throw new Exception(ErrorConstant.NotFound);
            }

            if (signUpRequest.IsApproved)
            {
                throw new Exception(ErrorConstant.AlreadyApproved);
            }

            Staff staff = await approvalRepositary.GetStaffCode(signUpRequest.StaffCode);

            if (staff == null)
            {
                throw new Exception("Staff not found");
            }

            signUpRequest.IsApproved = true;

            User user = new User()
            {
                Email = signUpRequest.Email,
                PasswordHash = signUpRequest.PasswordHash,
                Role = RoleEnum.Student,
                IsActive = true
            };

            Student student = new Student()
            {
                RollNo = signUpRequest.RollNo,
                Name = signUpRequest.Name,
                Email = signUpRequest.Email,
                PhoneNumber = approveStudentDto.PhoneNumber,
                StaffId = staff.Id
            };

            await approvalRepositary.AddStudent(student);
            approvalRepositary.UpdateStudentRequest(signUpRequest);
            await approvalRepositary.AddUser(user);

            await approvalRepositary.Save();
        }
    }
}
