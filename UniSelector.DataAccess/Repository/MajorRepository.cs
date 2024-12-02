using Microsoft.EntityFrameworkCore;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.DataAccess.Repository;

public class MajorRepository : Repository<Major>, IMajorRepository
{
    private readonly ApplicationDbContext _db;
    
    public MajorRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Major major)
    {
        // Completely remove any existing tracked entity with the same ID
        var trackedEntity = _db.Majors.Local.FirstOrDefault(e => e.Id == major.Id);
        if (trackedEntity != null)
        {
            _db.Entry(trackedEntity).State = EntityState.Detached;
        }

        // Force a complete reload of the entity state
        _db.Entry(major).State = EntityState.Modified;
    }   
}