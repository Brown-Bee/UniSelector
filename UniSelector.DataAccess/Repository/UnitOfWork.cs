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
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IUniversityRepository University { get; private set; }
        public IFacultyRepository Faculty { get; private set; }

        public IStandardFacultyRepository StandardFaculty { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            University = new UniversityRepository(_db);
            Faculty = new FacultyRepository(_db);
            StandardFaculty = new StandardFacultyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_userManager);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        
    }
}
