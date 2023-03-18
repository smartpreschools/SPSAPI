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
    public class SubscriberService : EntityService<Subscriber>, ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        public SubscriberService(IUnitOfWork unitOfWork, ISubscriberRepository subscriberRepository) :
            base(unitOfWork, subscriberRepository)
        {
            UnitOfWork = unitOfWork;
            _subscriberRepository = subscriberRepository;
        }
        public Result<Subscriber> Add(Subscriber cm)
        {
            var res = new Result<Subscriber>()
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

        public Result<Subscriber> Delete(int id)
        {
            var res = new Result<Subscriber>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var cm = _subscriberRepository.GetSubscriberById(id);
            if (cm == null)
            {
                res.Errors.Add($"We could not find the subscriber with id = {id.ToString()}");
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

        public Result<Subscriber> Edit(int id, Subscriber cm)
        {
            var res = new Result<Subscriber>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var cmDataById = _subscriberRepository.GetSubscriberById(id);
            if (cmDataById == null)
            {
                res.Errors.Add($"We could not find the subscriber with id = {id.ToString()}");
                return res;
            }
            
            cmDataById.SubscriberName = cm.SubscriberName;
            cmDataById.SubscriberAddress = cm.SubscriberAddress;
            cmDataById.Email = cm.Email;
            cmDataById.Mobile = cm.Mobile;
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

        public IEnumerable<Subscriber> GetSubscriber()
        {
            return _subscriberRepository.GetSubscriber();
        }
        public Subscriber GetSubscriberById(int subscriberMasterId)
        {
            return _subscriberRepository.GetSubscriberById(subscriberMasterId);
        }
    }
}
