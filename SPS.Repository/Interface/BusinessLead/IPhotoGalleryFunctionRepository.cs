
using SPS.Data.Models;
using SPS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Repository.Interface
{
    public interface IPhotoGalleryFunctionRepository : IGenericRepository<PhotoGalleryFunction>
    {
        IEnumerable<PhotoGalleryFunction> GetPhotoGalleryFunction();
        PhotoGalleryFunction GetPhotoGalleryFunctionById(int photoGalleryFunctionId);
        PhotoGalleryFunction PostPhotoGalleryFunction(int photoGalleryFunctionId,int subscriberMasterId);
    }
}



