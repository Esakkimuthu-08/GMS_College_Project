using Grievance_Management_System.Enum;
using Microsoft.EntityFrameworkCore;

namespace Grievance_Management_System.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Staff
    {
        public int Id { get; set; }
        public string StaffCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Student> Students { get; set; }
    }

}
