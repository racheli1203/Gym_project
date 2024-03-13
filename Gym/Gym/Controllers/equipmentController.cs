using AutoMapper;
using Gym.Core.DTO;
using Gym.Core.Models;
using Gym.Core.PostPutModel;
using Gym.Core.ServicesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equipmentController : ControllerBase
    {
        
        private readonly IEquipmentService _equipment;
        private readonly IMapper _mapperEquipment;
        public equipmentController(IEquipmentService context, IMapper mapper)
        {
            _equipment = context;
            _mapperEquipment = mapper;
        }


        // GET: api/<equipmentController>
        [HttpGet]
        public async Task<ActionResult<gymEquipment>>Get()
        {
            var list= await _equipment.GetEquipmentAsync();
            var listDto = _mapperEquipment.Map<IEnumerable<EquipmentDto>>(list);
            return Ok(listDto);
        }

        // GET api/<equipmentController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            
                var listId= await _equipment.GetEquipmentIdAsync(id);
                var equipmentDto = _mapperEquipment.Map<EquipmentDto>(listId);
                 return Ok(equipmentDto);
          
        }

        // POST api/<equipmentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EquipmentModel newEquipment)
        {
            var equipmentPost = new gymEquipment { name = newEquipment.name, dateOfInspection = newEquipment.dateOfInspection, category = newEquipment.category, frequencyOfTesting = newEquipment.frequencyOfTesting, expiryDate = newEquipment.expiryDate };
            await _equipment.PostEquipmentAsync(equipmentPost);
            return Ok(newEquipment);  
        }

      

        // PUT api/<equipmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EquipmentModel newEquipment)
        {
            var equipmentPut = new gymEquipment { name = newEquipment.name, dateOfInspection = newEquipment.dateOfInspection, category = newEquipment.category, frequencyOfTesting = newEquipment.frequencyOfTesting, expiryDate = newEquipment.expiryDate };
            await _equipment.PutEquipmentAsync(id, equipmentPut);
            return Ok(newEquipment) ;
        }
        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedEquipment = await _equipment.DeleteEquipmentAsync(id);
            if (deletedEquipment != null)
            {
                return Ok(deletedEquipment); 
            }
             return NotFound();       
        }


    }
}
