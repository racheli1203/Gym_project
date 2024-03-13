using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.ServicesModels
{
    public interface IEquipmentService
    {
        public Task<IEnumerable<gymEquipment>> GetEquipmentAsync();

        public Task<gymEquipment> GetEquipmentIdAsync(int id);

        public Task<gymEquipment> PostEquipmentAsync(gymEquipment value);

        public  Task<gymEquipment> PutEquipmentAsync(int id, gymEquipment value);


        public Task<gymEquipment> DeleteEquipmentAsync(int id);

        //void PostEquipment(gymEquipment value);


    }
}
