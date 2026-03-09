using Grievance_Management_System.Auth;
using Grievance_Management_System.Constants;
using Grievance_Management_System.Model;
using Grievance_Management_System.Model.Auth;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;

namespace Grievence_Management_System_Project.Service
{
    public class AuthService(IAuthRepositary authRepositary) : IAuthService
    {
        public async Task StaffSignUp(StaffSignUpRequest staffSignUpRequest)
        {
            StaffSignUp EmailExist = await authRepositary.StaffEmailExist(staffSignUpRequest.Email);

            if (EmailExist != null)
            {
                if (EmailExist.IsApproved)
                {
                    throw new Exception(ErrorConstant.AccountExist);
                }
                else
                {
                    throw new Exception(ErrorConstant.AccountPending);
                }
            }

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

        public async Task StudentSignUp(StudentSignUpRequest studentSignUpRequest)
        {
            StudentSignUp student = await authRepositary.StudentEmailExist(studentSignUpRequest.Email);
            bool staffCode = await authRepositary.StaffCodeExist(studentSignUpRequest.StaffCode);
            
            if(!staffCode)
            {
                throw new Exception(ErrorConstant.NotFound);
            }

            if (student != null)
            {
                if (student.IsApproved)
                {
                    throw new Exception(ErrorConstant.AccountExist);
                }
                else
                {
                    throw new Exception(ErrorConstant.AccountPending);
                }
            }
            StudentSignUp studentSignUp = new StudentSignUp()
            {
                RollNo = studentSignUpRequest.RollNo,
                Name = studentSignUpRequest.Name,
                Email = studentSignUpRequest.Email,
                PasswordHash = studentSignUpRequest.PasswordHash,
                StaffCode = studentSignUpRequest.StaffCode,
                IsApproved = false
            };
            await authRepositary.StudentSignUp(studentSignUp);
        }

        public async  Task<List<StudentSignUp>> GetAllStudentSignUp()
        {
            return await authRepositary.GetAllStudentSignUp();
        }
    }
}
