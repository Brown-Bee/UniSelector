﻿using Microsoft.EntityFrameworkCore;
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
        
    }
}
