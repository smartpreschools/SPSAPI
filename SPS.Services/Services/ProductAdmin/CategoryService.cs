using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Services.Interface;
using SPS.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Services
{


    public class CategoryService : EntityService<CategoryDetail>, ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(unitOfWork, categoryRepository)
        {
            UnitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDetail> GetCategory()
        {
            return _categoryRepository.GetCategory(); ;
        }
    }
}
