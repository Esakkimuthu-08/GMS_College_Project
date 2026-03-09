using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Model;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grievence_Management_System_Project.Repositary
{
    public class StudentRepositary(GrievenceDbContext grievenceDbContext) : IStudentRepositary
    {
        public async Task<List<Student>> GetAllStudents()
        {
            return await grievenceDbContext.Students.ToListAsync();
        }
    }
}
