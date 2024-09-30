using UniSelector.Models;

namespace UniSelector.DataAccess.Repository.IRepository
{
    public interface IUniversityRepository : IRepository<University>
    {
        void Update(University obj);
        IEnumerable<University> Search(string searchString);
        University GetWithGalleryImages(int id);
    }
}
