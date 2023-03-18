using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Repository.Interface
{
    public interface ICategoryRepository : IGenericRepository<CategoryDetail>
    {
        IEnumerable<CategoryDetail> GetCategory();
    }
}
