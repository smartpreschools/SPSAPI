
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
    public class PhotoGalleryFunctionService : EntityService<PhotoGalleryFunction>, IPhotoGalleryFunctionService
    {
        private readonly IPhotoGalleryFunctionRepository _photoGalleryFunctionRepository;
        public PhotoGalleryFunctionService(IUnitOfWork unitOfWork, IPhotoGalleryFunctionRepository photoGalleryFunctionRepository) :
            base(unitOfWork, photoGalleryFunctionRepository)
        {
            UnitOfWork = unitOfWork;
            _photoGalleryFunctionRepository = photoGalleryFunctionRepository;
        }
        public Result<PhotoGalleryFunction> Add(PhotoGalleryFunction cm)
        {
            var res = new Result<PhotoGalleryFunction>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            Create(cm);
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = cm;
            }
            return res;
        }

        public Result<PhotoGalleryFunction> Delete(int id)
        {
            var res = new Result<PhotoGalleryFunction>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var cm = _photoGalleryFunctionRepository.GetPhotoGalleryFunctionById(id);
            if (cm == null)
            {
                res.Errors.Add($"We could not find the Function with id = {id.ToString()}");
                return res;
            }
            cm.IsStatus = false;
            Update(cm);
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = cm;
            }
            return res;
        }

        public Result<PhotoGalleryFunction> Edit(int id, PhotoGalleryFunction cm)
        {
            var res = new Result<PhotoGalleryFunction>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var cmDataById = _photoGalleryFunctionRepository.GetPhotoGalleryFunctionById(id);
            if (cmDataById == null)
            {
                res.Errors.Add($"We could not find the subscriber with id = {id.ToString()}");
                return res;
            }

            cmDataById.FunctionName = cm.FunctionName;
            cmDataById.FunctionDescription = cm.FunctionDescription;

            cmDataById.ModifiedBy = cm.ModifiedBy;
            cmDataById.ModifiedDate = DateTime.Now;

            Update(cmDataById);
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = cmDataById;
            }
            return res;
        }

        public IEnumerable<PhotoGalleryFunction> GetPhotoGalleryFunction()
        {
            return _photoGalleryFunctionRepository.GetPhotoGalleryFunction();
        }
        public PhotoGalleryFunction GetPhotoGalleryFunctionById(int photoGalleryFunctionMasterId)
        {
            return _photoGalleryFunctionRepository.GetPhotoGalleryFunctionById(photoGalleryFunctionMasterId);
        }
    }
}
