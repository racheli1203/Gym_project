using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.ServicesModels
{
    public interface IStaffService
    {
        public Task<IEnumerable<Staff>> GetStaffAsync();

        public  Task<Staff> GetStaffIdAsync(int workerNumber);

        public Task<IEnumerable<Staff>> GetPositionAsync(string position);

        public  Task<Staff> ServicePostAsync(Staff newWorker);

        public Task<Staff> ServicePutAsync(int workerNumber, Staff updateWorker);
    }
}
