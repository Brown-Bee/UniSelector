using UniSelector.Models;

namespace UniSelector.DataAccess.Repository.IRepository;

public interface IMajorRepository : IRepository<Major>
{
    void Update(Major major);
    decimal GetAcceptanceRate(int majorId);
    decimal GetRejectionRate(int majorId);
    int TotalApplications(int majorId);
}