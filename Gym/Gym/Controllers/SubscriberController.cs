using AutoMapper;
using Gym.Core.DTO;
using Gym.Core.Models;
using Gym.Core.PostPutModel;
using Gym.Core.ServicesModels;
using Gym.Servies.ServiesRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {

        private readonly ISubscriberService _subscriberServies;
        private readonly IMapper _mapperSubscriber;

        public SubscriberController(ISubscriberService subscriberServies,IMapper mapper)
        {
            _subscriberServies = subscriberServies;
            _mapperSubscriber = mapper;
        }
        // GET: api/<SubscriptionsController>
        [HttpGet]
        public async Task< ActionResult<Subscribers>> Get()
        {
                var list=await _subscriberServies.GetSubscriberAsync();
                var listDto = _mapperSubscriber.Map<IEnumerable<SubscriberDto>>(list);
            return Ok(listDto);

        }

        // GET api/<SubscriptionsController>/5
        [HttpGet("{subscriptionNumber}")]
        public async Task<ActionResult> Get(int subscriptionNumber)
        {
                var subscriptionID=await _subscriberServies.GetByIdAsync(subscriptionNumber);
                var  subscriberDto = _mapperSubscriber.Map<SubscriberDto>(subscriptionID);

            return Ok(subscriberDto);
        }

        // POST api/<SubscriptionsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubscricersModel newSubscriber)
        {
            var subscriberPost = new Subscribers { idSubscriber=newSubscriber.idSubscriber,name= newSubscriber.name,dateOfBirth= newSubscriber.dateOfBirth,phone= newSubscriber.phone, email = newSubscriber.email, trainerId= newSubscriber.trainerId };
            var sub= await _subscriberServies.ServicePostAsync(subscriberPost);
            return Ok(sub);
        }

        // PUT api/<SubscriptionsController>/5
        [HttpPut("{subscriptionNumber}")]
        public async Task<ActionResult> Put(int subscriptionNumber, [FromBody] SubscricersModel newSubscriber)
        {
            var subscriberPut = new Subscribers { idSubscriber = newSubscriber.idSubscriber, name = newSubscriber.name, dateOfBirth = newSubscriber.dateOfBirth, phone = newSubscriber.phone, email = newSubscriber.email, trainerId = newSubscriber.trainerId };
            await _subscriberServies.ServicePutAsync(subscriptionNumber, subscriberPut);
             return Ok(newSubscriber) ;
        }

       
    }
}
