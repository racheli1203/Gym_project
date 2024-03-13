using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models
{
    public interface IStaff
    {
        public  Task<IEnumerable<Staff>> GetAllStaffAsync();

        public  Task<Staff> DataPostAsync(Staff newWorker);

        public  Task<Staff> DataPutAsync(int index, Staff updateWorker);





    }
}
