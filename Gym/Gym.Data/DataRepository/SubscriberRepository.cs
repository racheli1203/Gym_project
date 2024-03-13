using Gym.Core.Models;
using Gym.Data.DataContext;
using Gym.Servies.ServiesRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Data.DataRepository
{
    public class SubscriberRepository:ISubscriber
    {
        private readonly GymData _subscriberData;

        public SubscriberRepository(GymData subscriberData)
        {
            _subscriberData = subscriberData;
        }
        public async Task<IEnumerable<Subscribers>> GetAllSubscriberAsync()
        {
            return await _subscriberData.subscribers.Include(s=>s.trainer).ToListAsync();
        }
        public async Task<Subscribers> DataPostAsync(Subscribers newSubscriber)
        {
            _subscriberData.subscribers.Add(newSubscriber);
            await _subscriberData.SaveChangesAsync();
            return newSubscriber;


        }
        public  async Task<Subscribers> DataPutAsync(int index, Subscribers value)
        {
            _subscriberData.subscribers.ToList()[index] = value;
           await  _subscriberData.SaveChangesAsync();
            return value;
        }



    }
}
