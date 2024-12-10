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

    public decimal GetAcceptanceRate(int majorId)
    {
        // Get all applications for this major
        var applications = _db.Applications
            .Where(a => a.MajorId == majorId)
            .ToList();

        // If no applications, return 0
        if (!applications.Any()) { return 0; }

        // Count accepted applications
        var acceptedCount = applications.Count(a => a.Response == "Accepted");

        // Calculate rate
        return (decimal)acceptedCount/applications.Count * 100;
    }
    public decimal GetRejectionRate(int majorId)
    {
        // Get all applications for this major
        var applications = _db.Applications
            .Where(a => a.MajorId == majorId)
            .ToList();

        // If no applications, return 0
        if (!applications.Any() ) { return 0; }

        // Count accepted applications
        var rejectedCount = applications.Count(a => a.Response == "Rejected");

        // Calculate rate
        return (decimal)rejectedCount/applications.Count * 100;
    }
    public int TotalApplications(int majorId)
    {
        // Get all applications for this major
        var applications = _db.Applications
            .Where(a => a.MajorId == majorId)
            .ToList();

        // If no applications, return 0
        if (!applications.Any()) { return 0; }

        // Calculate rate
        return applications.Count;
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