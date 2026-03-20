using Grievance_Management_System.Auth;
using Grievance_Management_System.Constants;
using Grievance_Management_System.Enum;
using Grievance_Management_System.Model;
using Grievance_Management_System.Model.Auth;
using Grievance_Management_System.Request;
using Grievance_Management_System.Service;
using Grievence_Management_System_Project.Exceptions;
using Grievence_Management_System_Project.Model;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;

namespace Grievence_Management_System_Project.Service
{
    public class ApprovalService(IApprovalRepositary approvalRepositary , TokenService tokenService) : IApprovalService
    {
        public async Task ApproveStaff(ApproveStaffDto approveStaffDto)
        {
            StaffSignUp staffRequest = await approvalRepositary
                .GetStaffRequestId(approveStaffDto.SignupRequestId)
                ?? throw new NotFoundException();

            if (staffRequest.IsApproved)
            {
                throw new AlreadyApprovedException();
            }

            staffRequest.IsApproved = true;

            User user = new()
            {
                Email = staffRequest.Email,
                PasswordHash = staffRequest.PasswordHash,
                Role = RoleEnum.Staff,
                IsActive = true
            };

            Staff staff = new()
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
                .GetStudentRequestId(approveStudentDto.StudentSignUpId)
                ?? throw new NotFoundException();

            if (signUpRequest.IsApproved)
            {
                throw new AlreadyApprovedException();
            }

            Staff staff = await approvalRepositary
                .GetStaffCode(signUpRequest.StaffCode)
                ?? throw new NotFoundException();
            signUpRequest.IsApproved = true;

            User user = new()
            {
                Email = signUpRequest.Email,
                PasswordHash = signUpRequest.PasswordHash,
                Role = RoleEnum.Student,
                IsActive = true
            };

            Student student = new()
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

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var user = await approvalRepositary
                .GetUserByEmail(loginRequest.Email)
                ?? throw new NotFoundException();

            if (!user.IsActive)
                throw new AccountDisabledException();

           
            if (user.PasswordHash != loginRequest.Password)
                throw new UnauthorizedException();

            var token = tokenService.CreateToken(user);

            return token;
        }
    }
}
