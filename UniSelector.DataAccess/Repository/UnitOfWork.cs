using Microsoft.AspNetCore.Identity;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public IUniversityRepository University { get; private set; }
        public IFacultyRepository Faculty { get; private set; }

        public IStandardFacultyRepository StandardFaculty { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IMajorRepository Major { get; }

        public IStandardMajorRepository StandardMajor { get; private set; }
        public IApplicationRepository Application { get; private set; }

        public UnitOfWork(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            University = new UniversityRepository(_db);
            Faculty = new FacultyRepository(_db);
            StandardFaculty = new StandardFacultyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_userManager);
            Major = new MajorRepository(_db);
            StandardMajor = new StandardMajorRepository(_db);
            Application = new ApplicationRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        
    }
}
