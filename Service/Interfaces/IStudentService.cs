using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Model;

namespace Grievence_Management_System_Project.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
    }
}
