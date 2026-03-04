using Grievance_Management_System.Model;

namespace Grievence_Management_System_Project.Repositary.Interfaces
{
    public interface IStaffRepositary
    {
        Task CreateStaff(Staff staff);
        Task<List<Staff>> GetAllStaffs();
    }
}
