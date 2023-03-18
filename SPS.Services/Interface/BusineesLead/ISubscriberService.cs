using SPS.Data.Models;
using SPS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Interface
{
    public interface ISubscriberService : IEntityService<Subscriber>
    {
        Result<Subscriber> Add(Subscriber cm);
        Result<Subscriber> Delete(int id);
        Result<Subscriber> Edit(int id, Subscriber cm);
        IEnumerable<Subscriber> GetSubscriber();
        Subscriber GetSubscriberById(int subscriberMasterId);
    }
}
