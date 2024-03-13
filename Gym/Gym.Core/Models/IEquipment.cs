using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models
{
    public interface IEquipment
    {
        public  Task<IEnumerable<gymEquipment>> GetAllEquipmentAsync();

        public Task<gymEquipment> DataPostAsync(gymEquipment value);

        public Task<gymEquipment> DataPutAsync(int id, gymEquipment value);

        public Task<gymEquipment> DataDeleteEquipmentAsync(gymEquipment equipment);


    }
}
