using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;


public class FacultyRepository : Repository<Faculty> , IFacultyRepository
{
    private readonly ApplicationDbContext _db;

    public FacultyRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Faculty obj)
    {
        _db.Update(obj);
    }
}