using UniSelector.Models;

namespace UniSelector.DataAccess.Repository.IRepository;

public interface IMajorRepository : IRepository<Major>
{
    void Update(Major major);
}