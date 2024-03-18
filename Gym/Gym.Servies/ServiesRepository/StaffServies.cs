using Gym.Core.Models;
using Gym.Core.ServicesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Servies.ServiesRepository
{
    public class StaffServies: IStaffService
    {
        private static int IdCount = 1;
        private readonly IStaff _staff;
        public StaffServies(IStaff staff)
        {
            _staff = staff;
        }
        public async Task<IEnumerable<Staff>> GetStaffAsync()
        {
            return await _staff.GetAllStaffAsync();
        }
        public async Task<Staff> GetStaffIdAsync(int workerNumber)
        {
            var workerList = await _staff.GetAllStaffAsync();
            Staff foundWorker = workerList.First(t => t.workerNumber == workerNumber);
            if (foundWorker == null)
                return null; 
            return foundWorker;
        }
        public async Task<IEnumerable<Staff>> GetPositionAsync(string position)
        {
            var workerList = await _staff.GetAllStaffAsync();
            var foundpos=workerList.Where(t => t.position.ToLower() == position.ToLower());
            if (foundpos == null)
                return null;
            return foundpos;
        }
        public async Task<Staff> ServicePostAsync(Staff newWorker)
        {
            await _staff.DataPostAsync(newWorker);
            return newWorker;

        }

        public async Task<Staff> ServicePostEqAsync(int staffId, int equipmentId){
            Staff s= await _staff.DataPostEqToStaff(staffId, equipmentId);
            return s;
        }
       
        public async Task<Staff> ServicePutAsync(int workerNumber,  Staff updateWorker)
        {
            var list =await _staff.GetAllStaffAsync();
             var index= list.ToList(). FindIndex(( w) =>  w.workerNumber == workerNumber);
            list.ToList()[index].name = updateWorker.name;
            list.ToList()[index].dateOfBirth = updateWorker.dateOfBirth;
            list.ToList()[index].phone = updateWorker.phone;
            list.ToList()[index].email = updateWorker.email;
            list.ToList()[index].position = updateWorker.position;
            await _staff.DataPutAsync(index, updateWorker);
            return updateWorker;

           
        }






    }
}
