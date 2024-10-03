using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.DataAccess.Repository
{
    public class StandardFacultyRepository : Repository<StandardFaculty>, IStandardFacultyRepository
    {
        private ApplicationDbContext _db;

        public StandardFacultyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(StandardFaculty obj)
        {
            _db.StandardFaculties.Update(obj);
        }
    }
}
