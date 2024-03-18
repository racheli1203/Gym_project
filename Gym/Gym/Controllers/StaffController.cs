using AutoMapper;
using Gym.Core.DTO;
using Gym.Core.Models;
using Gym.Core.PostPutModel;
using Gym.Core.ServicesModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staff;
        private readonly IMapper _mapperStff;

        public StaffController(IStaffService context,IMapper mapper)
        {
            _staff = context;
            _mapperStff = mapper;
        }
       
        private static int IdCount = 4;

        // GET: api/<StaffController>
        [HttpGet]
        public async Task< ActionResult<Staff>> Get()
        {
            var list = await _staff.GetStaffAsync();
            var listDto = _mapperStff.Map<IEnumerable<StaffDto>>(list);
            return Ok(listDto);
        }

        // GET api/<StaffController>/5
        [HttpGet("{workerNumber}")]
        public async Task<ActionResult>Get(int workerNumber)
        {
          
            var staffObg =await _staff.GetStaffIdAsync(workerNumber);
            var staffObgDto= _mapperStff.Map<StaffDto>(staffObg);

            return Ok(staffObgDto) ;
        }
        // GET api/<StaffController>/5
        [HttpGet("getbytype/{position}")]
        public async Task<ActionResult<Staff>> Get(string position)
        {

            var positionList =await _staff.GetPositionAsync(position);
            var listDto = _mapperStff.Map<IEnumerable<StaffDto>>(positionList);
            return Ok(listDto) ;
        }
      

        // POST api/<StaffController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StaffModel newWorker)
        {
            var staffPost = new Staff { id = newWorker.id, name = newWorker.name, dateOfBirth = newWorker.dateOfBirth, phone = newWorker.phone, address = newWorker.address, email = newWorker.email, status = newWorker.status, position = newWorker.position };
             await _staff.ServicePostAsync(staffPost);
            return Ok(newWorker);
        }
        // POST api/<StaffController>
        [HttpPost("equipment")]
        public async Task<ActionResult> Post(int staffId, int equipmentId)
        {
            var eqToStaff= await _staff.ServicePostEqAsync(staffId, equipmentId);
            return Ok(eqToStaff);

            //var staffPost = new Staff { id = newWorker.id, name = newWorker.name, dateOfBirth = newWorker.dateOfBirth, phone = newWorker.phone, address = newWorker.address, email = newWorker.email, status = newWorker.status, position = newWorker.position };
            //await _staff.ServicePostAsync(staffPost);
            //return Ok(newWorker);
        }

        // PUT api/<StaffController>/5
        [HttpPut("{workerNumber}")]
        public  async Task<ActionResult> Put(int workerNumber, [FromBody] StaffModel newWorker)
        {
            var staffPut= new Staff { id = newWorker.id, name = newWorker.name, dateOfBirth = newWorker.dateOfBirth, phone = newWorker.phone, address = newWorker.address, email = newWorker.email, status = newWorker.status, position = newWorker.position };
            await _staff.ServicePutAsync(workerNumber, staffPut);
           return Ok(newWorker);
        }
    
    }
}
