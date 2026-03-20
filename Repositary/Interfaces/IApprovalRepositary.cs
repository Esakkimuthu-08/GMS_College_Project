using Grievance_Management_System.Auth;
using Grievance_Management_System.Model;
using Grievance_Management_System.Model.Auth;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Model;

namespace Grievence_Management_System_Project.Repositary.Interfaces
{
    public interface IApprovalRepositary
    {
        Task<StaffSignUp> GetStaffRequestId(int id);
        Task<StudentSignUp> GetStudentRequestId(int id);
        void UpdateStaffRequest(StaffSignUp staff);
        Task AddUser(User user);
        Task AddStaff(Staff staff);
        Task Save();
        void UpdateStudentRequest(StudentSignUp student);
        Task AddStudent(Student student);

        Task<Staff> GetStaffCode(string code);
        Task<User> GetUserByEmail(string Email);
        

    }
}
