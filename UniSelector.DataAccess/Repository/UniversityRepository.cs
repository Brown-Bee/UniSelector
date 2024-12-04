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
                objFromDb.Email = obj.Email;
                objFromDb.FullDescription = obj.FullDescription;
                objFromDb.SmallDescription = obj.SmallDescription;
                objFromDb.location = obj.location;
                objFromDb.KuwaitRank = obj.KuwaitRank;
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
                                            || u.FullDescription.Contains(searchString)                                           
                                            || u.SmallDescription.Contains(searchString))                                            
                                   .ToList();
        }
        

        public University? GetUniversityWithFaculties(int id)
        {
            return _db.Universities
                .Include(u => u.Faculties)
                .ThenInclude(u => u.StandardFaculty)
                .FirstOrDefault(u => u.Id == id);
        }
        
        public async Task<List<University>> FilterUniversities(UniversityFilter filter)
        {
            var query = _db.Universities
                .Include(u => u.Faculties)
                .ThenInclude(f => f.StandardFaculty)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.UniversityType))
            {
                query = query.Where(u => u.type == filter.UniversityType);
            }

            if (!string.IsNullOrEmpty(filter.Faculty))
            {
                query = query
                    .Where(u => u.Faculties
                        .Any(f => f.StandardFaculty != null && f.StandardFaculty.Id.ToString() == filter.Faculty))
                    .AsQueryable();
            }
            if (!string.IsNullOrEmpty(filter.Major))
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .ThenInclude(m => m.StandardMajor)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.StandardMajor != null && m.StandardMajor.Id.ToString() == filter.Major)));
            }

            if (filter.MinimumGrade.HasValue)
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.MinimumGrade <= filter.MinimumGrade)));
            }

            if (filter.IeltsScore.HasValue)
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.MinimumIELTS >= filter.IeltsScore)));
            }

            if (filter.ToeflScore.HasValue)
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.MinimumTOEFL >= filter.ToeflScore)));
            }

            if (!string.IsNullOrEmpty(filter.HighSchoolPath))
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .ThenInclude(m => m.StandardMajor)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.StandardMajor!.HighSchoolPath == filter.HighSchoolPath)));            }

            if (filter.MinPrice.HasValue)
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.AveragePrice >= filter.MinPrice)));
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query
                    .Include(u => u.Faculties)
                    .ThenInclude(f => f.Majors)
                    .Where(u => u.Faculties.Any(f => f.Majors.Any(m => m.AveragePrice <= filter.MaxPrice)));
            }

            if (filter.MaxRank.HasValue)
            {
                query = query
                    .Where(u => u.KuwaitRank <= filter.MaxRank);
            }

            return await query.ToListAsync();
        }
        
    }
}

