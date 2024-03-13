using Gym.Core.Models;
using Gym.Core.ServicesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Gym.Servies.ServiesRepository
{
    public class EquipmentServies: IEquipmentService
    {
        private static int IdCount = 1;

        private readonly IEquipment _equipment;
        public EquipmentServies(IEquipment equipment)
        {
            _equipment = equipment;
        }
        public async Task<IEnumerable<gymEquipment>> GetEquipmentAsync()
        {
            return await _equipment.GetAllEquipmentAsync();
        }

        public async Task<gymEquipment> GetEquipmentIdAsync(int id)
        {
            var equipmentList = await _equipment.GetAllEquipmentAsync();
            gymEquipment equipment = equipmentList.First(e => e.id == id);
            return equipment;
        }


        public async Task<gymEquipment> PostEquipmentAsync(gymEquipment value)
        {
             await _equipment.DataPostAsync(value);
            return value;
        }

        public async Task<gymEquipment> PutEquipmentAsync(int id, gymEquipment value)
        {
            var list = await _equipment.GetAllEquipmentAsync();
            var index = list.ToList().FindIndex((e) => e.id == id);
            list.ToList()[index].name = value.name;
            list.ToList()[index].dateOfInspection = value.dateOfInspection;
            list.ToList()[index].category = value.category;
            list.ToList()[index].frequencyOfTesting = value.frequencyOfTesting;
            list.ToList()[index].expiryDate = value.expiryDate;
            await _equipment.DataPutAsync(index, value);
            return value;
        }

        public async Task<gymEquipment> DeleteEquipmentAsync(int id)
        {
            var equipmentList = await _equipment.GetAllEquipmentAsync();
            gymEquipment equipmentDel = equipmentList.First((gymEquipment e) => e.id == id);
            if (equipmentDel != null)
            {
               return await _equipment.DataDeleteEquipmentAsync(equipmentDel);
            }
            return null;

        }
    }
}
