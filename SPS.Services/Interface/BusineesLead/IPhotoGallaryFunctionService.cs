
using SPS.Data.Models;
using SPS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Interface
{
    public interface IPhotoGallaryFunctionService : IEntityService<PhotoGallaryFunction>
    {
        Result<PhotoGallaryFunction> Add(PhotoGallaryFunction cm);
        Result<PhotoGallaryFunction> Delete(int id);
        Result<PhotoGallaryFunction> Edit(int id, PhotoGallaryFunction cm);
        IEnumerable<PhotoGallaryFunction> GetPhotoGallaryFunction();
        PhotoGallaryFunction GetPhotoGallaryFunctionById(int photoGallaryFunctionMasterId);
    }
}
