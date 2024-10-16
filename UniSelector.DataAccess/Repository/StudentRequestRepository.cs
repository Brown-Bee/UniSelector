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
    public class StudentRequestRepository : Repository<StudentRequest>, IStudentRequestRepository
    {
        private ApplicationDbContext _db;
        public StudentRequestRepository(ApplicationDbContext db) : base(db)
        {
            {
                _db = db;
            }
        }
        public void Update(StudentRequest obj)
        {
            _db.StudetsRequests.Update(obj);
        }
    }
}
