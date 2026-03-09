using Grievance_Management_System.Enum;
using Grievence_Management_System_Project.Model;
using Microsoft.EntityFrameworkCore;

namespace Grievance_Management_System.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Staff
    {
        public int Id { get; set; }
        public string StaffCode { get; set; }
        public string Name { get; set; } = string.Empty;    
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Student> Students { get; set; }
    }

}
