
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
    public class PhotoGallaryFunctionRepository : GenericRepository<PhotoGallaryFunction>, IPhotoGallaryFunctionRepository
    {
        public PhotoGallaryFunctionRepository(SPSContext context) : base(context)
        {
        }

        public IEnumerable<PhotoGallaryFunction> GetPhotoGallaryFunction()
        {
            return Context.PhotoGallaryFunction.Where(x => x.IsStatus == true).ToList();
        }
        public PhotoGallaryFunction GetPhotoGallaryFunctionById(int photoGallaryFunctionMasterId)
        {
            return FirstOrDefault(x => x.FunctionId == photoGallaryFunctionMasterId && x.IsStatus == true);
        }
    }
}
