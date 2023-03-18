﻿
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
    public class PhotoGallaryFunctionService : EntityService<PhotoGallaryFunction>, IPhotoGallaryFunctionService
    {
        private readonly IPhotoGallaryFunctionRepository _photoGallaryFunctionRepository;
        public PhotoGallaryFunctionService(IUnitOfWork unitOfWork, IPhotoGallaryFunctionRepository photoGallaryFunctionRepository) :
            base(unitOfWork, photoGallaryFunctionRepository)
        {
            UnitOfWork = unitOfWork;
            _photoGallaryFunctionRepository = photoGallaryFunctionRepository;
        }
        public Result<PhotoGallaryFunction> Add(PhotoGallaryFunction cm)
        {
            var res = new Result<PhotoGallaryFunction>()
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

        public Result<PhotoGallaryFunction> Delete(int id)
        {
            var res = new Result<PhotoGallaryFunction>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var cm = _photoGallaryFunctionRepository.GetPhotoGallaryFunctionById(id);
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

        public Result<PhotoGallaryFunction> Edit(int id, PhotoGallaryFunction cm)
        {
            var res = new Result<PhotoGallaryFunction>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var cmDataById = _photoGallaryFunctionRepository.GetPhotoGallaryFunctionById(id);
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

        public IEnumerable<PhotoGallaryFunction> GetPhotoGallaryFunction()
        {
            return _photoGallaryFunctionRepository.GetPhotoGallaryFunction();
        }
        public PhotoGallaryFunction GetPhotoGallaryFunctionById(int photoGallaryFunctionMasterId)
        {
            return _photoGallaryFunctionRepository.GetPhotoGallaryFunctionById(photoGallaryFunctionMasterId);
        }
    }
}