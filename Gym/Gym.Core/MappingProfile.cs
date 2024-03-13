using AutoMapper;
using Gym.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core
{
    public  class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<gymEquipment, EquipmentDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Subscribers,SubscriberDto>().ReverseMap();
        }

    }
}
