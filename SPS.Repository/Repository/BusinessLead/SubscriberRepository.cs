using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Repository.Repository
{
    public class SubscriberRepository : GenericRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(SPSContext context) : base(context)
        {
        }

        public IEnumerable<Subscriber> GetSubscriber()
        {
            return Context.Subscriber.Where(x=>x.IsStatus==true).ToList();
        }
        public Subscriber GetSubscriberById(int subscriberMasterId)
        {
            return FirstOrDefault(x => x.SubscriberMasterId == subscriberMasterId && x.IsStatus==true);
        }
    }
}
