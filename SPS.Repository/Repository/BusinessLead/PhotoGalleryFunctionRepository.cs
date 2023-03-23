
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
    public class PhotoGalleryFunctionRepository : GenericRepository<PhotoGalleryFunction>, IPhotoGalleryFunctionRepository
    {
        public PhotoGalleryFunctionRepository(SPSContext context) : base(context)
        {
        }

        public IEnumerable<PhotoGalleryFunction> GetPhotoGalleryFunction()
        {
            return Context.PhotoGalleryFunction.Where(x => x.IsStatus == true).ToList();
        }
        public PhotoGalleryFunction GetPhotoGalleryFunctionById(int photoGalleryFunctionMasterId)
        {
            return FirstOrDefault(x => x.FunctionId == photoGalleryFunctionMasterId && x.IsStatus == true);
        }
    }
}
