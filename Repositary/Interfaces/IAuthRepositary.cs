using Grievance_Management_System.Auth;
using Grievance_Management_System.Model;
using Grievance_Management_System.Model.Auth;
using Grievance_Management_System.Request;

namespace Grievence_Management_System_Project.Repositary.Interfaces
{
    public interface IAuthRepositary
    {
        Task StaffSignUp(StaffSignUp staffSignUp);
        Task<StaffSignUp> StaffEmailExist(string Email);
        Task<List<StaffSignUp>> GetAllStaffRequest();
        Task StudentSignUp(StudentSignUp studentSignUp);
        Task<StudentSignUp> StudentEmailExist(string Email);
        Task<bool> StaffCodeExist(string StaffCode);
        Task<List<StudentSignUp>> GetAllStudentSignUp();

        

    }
}
