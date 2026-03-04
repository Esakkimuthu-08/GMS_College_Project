using Grievance_Management_System.Model;
using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Grievence_Management_System_Project.Repositary
{
    public class StaffRepositary(GrievenceDbContext grievenceDbContext) : IStaffRepositary
    {
        public async Task CreateStaff(Staff staff)
        {
             await grievenceDbContext.Staffs.AddAsync(staff);
             await grievenceDbContext.SaveChangesAsync();
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
            return await grievenceDbContext.Staffs.ToListAsync();
        }
    }
}
