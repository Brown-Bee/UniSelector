using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;

namespace UniSelector.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IUniversityRepository University { get; private set; }
        public IFacultyRepository Faculty { get; private set; }



        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            University = new UniversityRepository(_db);
            Faculty = new FacultyRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        
    }
}
