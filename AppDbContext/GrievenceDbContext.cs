using Grievance_Management_System.Auth;
using Grievance_Management_System.Model;
using Grievance_Management_System.Model.Auth;
using Microsoft.EntityFrameworkCore;

namespace Grievence_Management_System_Project.AppDbContext
{
    public class GrievenceDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<StaffSignUp> StaffSignUp { get; set; }
        public DbSet<StudentSignUp> StudentSignUp { get; set; }
    }
}
