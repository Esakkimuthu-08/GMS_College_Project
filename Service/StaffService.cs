using Grievance_Management_System.Enum;
using Grievance_Management_System.Model;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;
using System.Threading.Tasks;

namespace Grievence_Management_System_Project.Service
{
    public class StaffService(IStaffRepositary staffRepositary) : IStaffService
    {
        public async Task CreateStaff(StaffRequest request)
        {
            Staff staff = new Staff
            {
                StaffCode = request.StaffCode,
                Name = request.Name,
                Email = request.Email,
                Role = RoleEnum.Admin,
                PhoneNumber = request.PhoneNumber
            };            
           await staffRepositary.CreateStaff(staff);
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
             return await staffRepositary.GetAllStaffs();
        }
    }
}
