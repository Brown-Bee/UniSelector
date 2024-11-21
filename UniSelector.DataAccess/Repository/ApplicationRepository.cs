using Microsoft.EntityFrameworkCore;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository;

public class ApplicationRepository : Repository<Application>, IApplicationRepository
{
    private readonly ApplicationDbContext _db;

    public ApplicationRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Application application)
    {
        _db.Applications.Update(application);
    }

    public void UpdateStatus(int id, string status, string? feedback)
    {
        var application = _db.Applications.Find(id);
        if (application != null)
        {
            application.Status = status;
            application.UniversityFeedback = feedback;
        }
    }

    public IEnumerable<Application> GetUserApplications(string userId)
    {
        return _db.Applications
            .Include(a => a.University)
            .Include(a => a.Faculty)
            .Include(a => a.Major)
            .Where(a => a.UserId == userId);
    }

    public IEnumerable<Application> GetUniversityApplications(int universityId)
    {
        return _db.Applications
            .Include(a => a.User)
            .Include(a => a.Faculty)
            .Include(a => a.Major)
            .Where(a => a.UniversityId == universityId);
    }
}