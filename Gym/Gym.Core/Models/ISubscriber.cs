using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models
{
    public interface ISubscriber
    {
        public Task<IEnumerable<Subscribers>> GetAllSubscriberAsync();

        public Task<Subscribers> DataPostAsync(Subscribers newSubscriber);

        public Task<Subscribers> DataPutAsync(int index, Subscribers value);

    }
}
