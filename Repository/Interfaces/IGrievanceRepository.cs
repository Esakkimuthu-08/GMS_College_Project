using Grievence_Management_System_Project.Model;

namespace Grievence_Management_System_Project.Repository.Interfaces
{
    public interface IGrievanceRepository
    {
        Task AddGrievance(RaiseGrievances raiseGrievances);
        Task<List<RaiseGrievances>> GetAllGrievances();

        Task<RaiseGrievances> GetById(int Id);

        Task UpdateStatus(RaiseGrievances grivance);
        
    }
}
