﻿using Gym.Core.Models;
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
        public IEnumerable<Subscribers> GetSubscriber()
        {
            return _subscriber.GetAllSubscriber();
        }
        public Subscribers GetById(int subscriptionNumber)
        {
            Subscribers subscriber = _subscriber.GetAllSubscriber().ToList().Find(s => s.subscriptionNumber == subscriptionNumber);
            if (subscriber == null)
                return null;
            return subscriber;

        }
        public void ServicePost(Subscribers newSubscriber)
        {
             _subscriber.DataPost(newSubscriber);
            IdCount++;
            //return newSubscriber;
        }
        public void ServicePut(int subscriptionNumber,  Subscribers value)
        {

            int index = _subscriber.GetAllSubscriber().ToList().FindIndex((w) => w.subscriptionNumber == subscriptionNumber );
            _subscriber.GetAllSubscriber().ToList()[index].idSubscriber = value.idSubscriber;
            _subscriber.GetAllSubscriber().ToList()[index].name = value.name;
            _subscriber.GetAllSubscriber().ToList()[index].dateOfBirth = value.dateOfBirth;
            _subscriber.GetAllSubscriber().ToList()[index].endSubscripion = value.endSubscripion;
            _subscriber.GetAllSubscriber().ToList()[index].phone = value.phone;
            _subscriber.GetAllSubscriber().ToList()[index].status = value.status;
            _subscriber.GetAllSubscriber().ToList()[index].email = value.email;
            _subscriber.GetAllSubscriber().ToList()[index].startSubscripion = value.startSubscripion;
            _subscriber.DataPut(index, value);
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
