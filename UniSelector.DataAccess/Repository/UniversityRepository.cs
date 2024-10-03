using Microsoft.EntityFrameworkCore;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.DataAccess.Repository
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public ApplicationDbContext _db;
        public UniversityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(University obj)
        {
            var objFromDb = _db.Universities.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.type = obj.type;
                objFromDb.Description = obj.Description;
                objFromDb.location = obj.location;
                objFromDb.KuwaitRank = obj.KuwaitRank;
                objFromDb.Budget = obj.Budget;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
        public IEnumerable<University> Search(string searchString)
        {
            return _db.Universities.Where(u => u.Name.Contains(searchString)
                                            || u.location.Contains(searchString)
                                            || u.Description.Contains(searchString))
                                   .ToList();
        }
        public University GetWithGalleryImages(int id)
        {
            return _db.Universities.Include(u => u.GalleryImages).Include(f => f.Faculties).FirstOrDefault(u => u.Id == id);
        }
    }
}
