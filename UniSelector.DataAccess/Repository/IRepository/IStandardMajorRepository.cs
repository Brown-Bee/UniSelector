using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniSelector.Models;

namespace UniSelector.DataAccess.Repository.IRepository
{
    public interface IStandardMajorRepository : IRepository<StandardMajor>
    {
        void Update(StandardMajor obj);
    }
}