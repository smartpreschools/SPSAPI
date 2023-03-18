using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Repository.Repository
{
    public class CategoryRepository : GenericRepository<CategoryDetail>, ICategoryRepository
    {
        public CategoryRepository(SPSContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDetail> GetCategory()
        {
            return Context.CategoryDetails.ToList();
        }
    }
}
