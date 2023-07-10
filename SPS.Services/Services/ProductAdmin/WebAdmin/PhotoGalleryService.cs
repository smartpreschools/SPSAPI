using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Repository.Repository;
using SPS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Services
{
    public class PhotoGalleryService : EntityService<PhotoGalleryFunction>, IPhotoGalleryService
    {
        private readonly IPhotoGallaryRepository _photoGallaryRepository;
        public PhotoGalleryService(IUnitOfWork unitOfWork, IPhotoGallaryRepository photoGallaryRepository) :
            base(unitOfWork, photoGallaryRepository)
        {
            UnitOfWork = unitOfWork;
            _photoGallaryRepository = photoGallaryRepository;
        }
        public Result<PhotoGalleryFunction> Add(PhotoGalleryFunction cm, int subscriberMasterId)
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
            var cm = _photoGallaryRepository.GetPhotoGallaryFunctionById(id);

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
            var cmDataById = _photoGallaryRepository.GetPhotoGallaryFunctionById(id);
            if (cmDataById == null)
            {
                res.Errors.Add($"We could not find the subscriber with id = {id.ToString()}");
                return res;
            }

            cmDataById.SubscriberMasterId = cm.SubscriberMasterId;
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
            return _photoGallaryRepository.GetPhotoGallaryFunction();
        }
        public PhotoGalleryFunction GetPhotoGalleryFunctionById(int photoGalleryFunctionId)
        {
            return _photoGallaryRepository.GetPhotoGallaryFunctionById(photoGalleryFunctionId);
        }
        
    }
}

