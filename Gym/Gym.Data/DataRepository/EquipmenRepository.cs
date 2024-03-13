using Gym.Core.Models;
using Gym.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Data.DataRepository
{
    public class EquipmenRepository: IEquipment
    {
        private readonly GymData _context;
        public EquipmenRepository(GymData equipmentData)
        {
            _context = equipmentData;
        }
        public async Task<IEnumerable<gymEquipment>> GetAllEquipmentAsync()
        {

            return await _context.equipments.Include(e => e.staffs).ToListAsync();
        }

        public async Task<gymEquipment> DataPostAsync(gymEquipment value)
        {
            _context.equipments.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }
        public async Task<gymEquipment> DataPutAsync(int index, gymEquipment value)
        {
            _context.equipments.ToList()[index] = value;
            await _context.SaveChangesAsync ();
            // _context.equipments; ToList()[index] = value;
            //_context.equipments.First((gymEquipment e) => e == value);
            //await _context.SaveChangesAsync();
            return value;
        }

        public async Task<gymEquipment> DataDeleteEquipmentAsync(gymEquipment equipment)
        {
            var temp = equipment;
            var deleteEquipment= _context.equipments.First((gymEquipment e) => e == equipment);
            _context.equipments.Remove(deleteEquipment);
            await _context.SaveChangesAsync();
            return temp;

        }







    }
}
