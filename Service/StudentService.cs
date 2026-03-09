using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Model;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;

namespace Grievence_Management_System_Project.Service
{
    public class StudentService(IStudentRepositary studentRepositary) : IStudentService
    {
        public async Task<List<Student>> GetAllStudents()
        {
            return await studentRepositary.GetAllStudents();
        }
    }
}
