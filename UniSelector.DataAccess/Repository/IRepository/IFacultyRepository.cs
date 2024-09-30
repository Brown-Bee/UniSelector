using UniSelector.Models;

namespace UniSelector.DataAccess.Repository.IRepository
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        public void Update(Faculty obj);
    }
}