using Grievance_Management_System.Auth;
using Grievance_Management_System.Request;
using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grievence_Management_System_Project.Repositary
{
    public class AuthRepositary(GrievenceDbContext grievenceDbContext) : IAuthRepositary
    {
        public async Task StaffSignUp(StaffSignUp staffSignUp)
        {
           await grievenceDbContext.StaffSignUp.AddAsync(staffSignUp);
           await grievenceDbContext.SaveChangesAsync();
        }

        public async Task<List<StaffSignUp>> GetAllStaffRequest()
        {
           return await grievenceDbContext.StaffSignUp.ToListAsync();
        }
    }
}
