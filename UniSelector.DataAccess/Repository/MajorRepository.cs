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
        _db.Update(major);
    }
}