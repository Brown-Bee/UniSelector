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
    public class StandardMajorRepository : Repository<StandardMajor>, IStandardMajorRepository
    {
        private ApplicationDbContext _db;

        public StandardMajorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(StandardMajor obj)
        {
            _db.StandardMajors.Update(obj);
        }
    }
}