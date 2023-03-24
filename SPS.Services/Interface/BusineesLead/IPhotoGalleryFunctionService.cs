
using SPS.Data.Models;
using SPS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Interface
{
    public interface IPhotoGalleryFunctionService : IEntityService<PhotoGalleryFunction>
    {
        Result<PhotoGalleryFunction> Add(PhotoGalleryFunction cm,int subscriberMasterId);
        Result<PhotoGalleryFunction> Delete(int id);
        Result<PhotoGalleryFunction> Edit(int id, PhotoGalleryFunction cm);
        IEnumerable<PhotoGalleryFunction> GetPhotoGalleryFunction();

        PhotoGalleryFunction GetPhotoGalleryFunctionById(int photoGalleryFunctionId);
        PhotoGalleryFunction PostPhotoGalleryFunction(int photoGalleryFunctionId,int subscriberMasterId);
    }
}
