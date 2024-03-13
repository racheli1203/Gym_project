using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.PostPutModel
{
    public class SubscricersModel
    {
        public int idSubscriber { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int trainerId { get; set; }
    }
}
