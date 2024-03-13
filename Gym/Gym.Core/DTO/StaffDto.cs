using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.DTO
{
    public class StaffDto
    {
        [Key]
        public int workerNumber { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string position { get; set; }
        //public List<int> subId { get; set; }


    }
}
