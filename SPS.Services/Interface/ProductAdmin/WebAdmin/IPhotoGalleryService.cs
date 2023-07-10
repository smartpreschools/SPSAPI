using SPS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPS.Services.Interface;

namespace SPS.Services.Interface
{
    public interface IPhotoGalleryService : IEntityService<PhotoGalleryFunction>
    {
        Result<PhotoGalleryFunction> Add(PhotoGalleryFunction cm,int subscriberMasterId);
        Result<PhotoGalleryFunction> Delete(int id);
        Result<PhotoGalleryFunction> Edit(int id, PhotoGalleryFunction cm);
        IEnumerable<PhotoGalleryFunction> GetPhotoGalleryFunction();

        PhotoGalleryFunction GetPhotoGalleryFunctionById(int photoGalleryFunctionId);
        
    }
}
