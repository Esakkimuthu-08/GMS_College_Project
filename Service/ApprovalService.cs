using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service.Interfaces;

namespace Grievence_Management_System_Project.Service
{
    public class ApprovalService(IApprovalRepositary approvalRepositary) : IApprovalService
    {
    }
}
