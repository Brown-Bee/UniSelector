using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository;
using UniSelector.Models;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository     
{
    private readonly ApplicationDbContext _db;

    public ApplicationUserRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public bool Update(ApplicationUser user)
    {
        _db.Update(user);
        return true;
    }
}