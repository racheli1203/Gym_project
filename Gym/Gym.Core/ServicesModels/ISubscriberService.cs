using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.ServicesModels
{
    public interface ISubscriberService
    {
        public  Task<IEnumerable<Subscribers>> GetSubscriberAsync();

        public  Task<Subscribers> GetByIdAsync(int subscriptionNumber);

        public  Task<Subscribers> ServicePostAsync(Subscribers newSubscriber);

        public  Task<Subscribers> ServicePutAsync(int subscriptionNumber, Subscribers value);


    }
}
