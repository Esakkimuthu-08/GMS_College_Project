using Grievence_Management_System_Project.Model;

namespace Grievence_Management_System_Project.Repositary.Interfaces
{
    public interface IStudentRepositary
    {
        Task<List<Student>> GetAllStudents();
    }
}
