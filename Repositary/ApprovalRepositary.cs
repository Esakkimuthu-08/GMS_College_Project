using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Repositary.Interfaces;

namespace Grievence_Management_System_Project.Repositary
{
    public class ApprovalRepositary(GrievenceDbContext grievenceDbContext) : IApprovalRepositary
    {
    }
}
