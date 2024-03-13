using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.DTO
{
    public class SubscriberDto
    {
        [Key]
        public int subscriptionNumber { get; set; }
        public int idSubscriber { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime startSubscripion { get; set; }
        public DateTime endSubscripion { get; set; }
        public string status { get; set; }
        public int trainerId { get; set; }
    }
}
