using Grievance_Management_System.Model;
using Grievance_Management_System.Request;

namespace Grievence_Management_System_Project.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
    }
}
