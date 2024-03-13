using Gym.Core.Models;
using Gym.Data.DataContext;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Data.DataRepository
{
    public class StaffRepository:IStaff
    {
        private readonly GymData _staffContext;
        public StaffRepository(GymData staffData)
        {
            _staffContext = staffData;
        }
        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _staffContext.Staffs.Include(s => s.subscribersId).Include(e=>e.equipmentInCategory).ToListAsync();
        }
        public async Task< Staff> DataPostAsync( Staff newWorker)
        {
             _staffContext.Staffs.Add(newWorker);
            await _staffContext.SaveChangesAsync();
            return newWorker;
        }
        public  async Task<Staff> DataPutAsync(int index, Staff updateWorker)
        {
            _staffContext.Staffs.ToList()[index] = updateWorker;
            await _staffContext.SaveChangesAsync();
            return updateWorker;
        }


   }
}
