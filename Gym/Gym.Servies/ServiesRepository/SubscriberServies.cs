using Gym.Core.Models;
using Gym.Core.ServicesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Servies.ServiesRepository
{
    public class SubscriberServies : ISubscriberService
    {
        private static int IdCount = 1;

        private readonly ISubscriber _subscriber;
        public SubscriberServies(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }
        public  async Task<IEnumerable<Subscribers> >GetSubscriberAsync()
        {
            return await _subscriber.GetAllSubscriberAsync();
        }
        public async Task<Subscribers> GetByIdAsync(int subscriptionNumber)
        {
            var list =await _subscriber.GetAllSubscriberAsync();
            Subscribers subscriber= list.First(s => s.subscriptionNumber == subscriptionNumber);
            if (subscriber == null)
                return null;
            return subscriber;
          

        }
        public async Task<Subscribers> ServicePostAsync(Subscribers newSubscriber)
        {
            await _subscriber.DataPostAsync(newSubscriber);
            return newSubscriber;
        }
        public async Task<Subscribers> ServicePutAsync(int subscriptionNumber,  Subscribers value)
        {

            var list = await _subscriber.GetAllSubscriberAsync();
            var index= list.ToList().FindIndex((w) => w.subscriptionNumber == subscriptionNumber );
            list.ToList()[index].idSubscriber = value.idSubscriber;
            list.ToList()[index].name = value.name;
            list.ToList()[index].dateOfBirth = value.dateOfBirth;
            list.ToList()[index].endSubscripion = value.endSubscripion;
            list.ToList()[index].phone = value.phone;
            list.ToList()[index].status = value.status;
            list.ToList()[index].email = value.email;
            list.ToList()[index].startSubscripion = value.startSubscripion;
            await _subscriber.DataPutAsync(index, value);
            return value;
            //Subscribers foundsub = _subscriber.GetAllSubscriber().Find(s => s.subscriptionNumber == subscriptionNumber);
            //if (foundsub != null)
            //{
            //    foundsub.id = foundsub.id;
            //    foundsub.phone = foundsub.phone;
            //    foundsub.email = value.email;
            //    foundsub.name = value.name;
            //    foundsub.status = value.status;
            //    foundsub.dateOfBirth = value.dateOfBirth;
            //    foundsub.endSubscripion = value.endSubscripion;
            //    foundsub.startSubscripion = value.startSubscripion;

            //}
            //return foundsub;
        }




    }
}
