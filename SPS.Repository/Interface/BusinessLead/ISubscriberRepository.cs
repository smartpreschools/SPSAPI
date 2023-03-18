using SPS.Data.Models;
using SPS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Repository.Interface
{
    public interface ISubscriberRepository : IGenericRepository<Subscriber>
    {
        IEnumerable<Subscriber> GetSubscriber();
        Subscriber GetSubscriberById(int subscriberMasterId);
    }
}
