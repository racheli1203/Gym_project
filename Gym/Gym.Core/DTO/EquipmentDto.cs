using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.DTO
{
    public class EquipmentDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateOfInspection { get; set; }//תאריך בדיקה
        public string category { get; set; }
        public int frequencyOfTesting { get; set; }//תדירות בדיקות
        public DateTime expiryDate { get; set; }
    }
}
