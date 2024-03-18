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
        //Staff foundWorker = workerList.First(t => t.workerNumber == workerNumber);

        //public async Task<Staff> DataPostEqToStaff(int staffId,int equipmentId)
        //{
        //    Staff postToStaff = _staffContext.Staffs.First(s => s.workerNumber == staffId);
        //    gymEquipment equipmentToSaff = _staffContext.equipments.First(e => e.id == equipmentId);
        //    postToStaff.equipmentInCategory.Prepend(equipmentToSaff);
        //    await _staffContext.SaveChangesAsync();
        //    return postToStaff;

        //}
        public async Task<Staff> DataPostEqToStaff(int staffId, int equipmentId)
        {
            // Find the staff member by ID
            Staff postToStaff = await _staffContext.Staffs
                                                .Include(s => s.equipmentInCategory) // Include equipmentInCategory navigation property
                                                .FirstOrDefaultAsync(s => s.workerNumber == staffId);

            // Find the equipment by ID
            gymEquipment equipmentToStaff = await _staffContext.equipments.FirstOrDefaultAsync(e => e.id == equipmentId);

            // Ensure the staff member and equipment exist
            if (postToStaff != null && equipmentToStaff != null)
            {
                // Initialize the equipmentInCategory collection if it's null
                if (postToStaff.equipmentInCategory == null)
                {
                    postToStaff.equipmentInCategory = new List<gymEquipment>();
                }

                // Always add the equipment to the end of the list
                postToStaff.equipmentInCategory.Add(equipmentToStaff);

                // Save changes to the database
                await _staffContext.SaveChangesAsync();
            }

            return postToStaff;
        }






    }
}
