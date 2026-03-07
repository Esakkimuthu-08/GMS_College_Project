using Grievance_Management_System.Auth;
using Grievance_Management_System.Model;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grievence_Management_System_Project.Repositary
{
    public class ApprovalRepositary(GrievenceDbContext grievenceDbContext) : IApprovalRepositary
    {
        public async Task<StaffSignUp> GetStaffRequestId(int id)
        {
            return await grievenceDbContext.StaffSignUp
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task AddStaff(Staff staff)
        {
            await grievenceDbContext.Staffs.AddAsync(staff);
        }
        public async Task AddUser(User user)
        {
            await grievenceDbContext.Users.AddAsync(user);
        }
        public void UpdateStaffRequest(StaffSignUp staff)
        {
            grievenceDbContext.StaffSignUp.Update(staff);
        }
        public async Task Save()
        {
            await grievenceDbContext.SaveChangesAsync();
        }
    }
}
