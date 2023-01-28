using API_Test.Data;
using API_Test.Dtos;
using API_Test.Models.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private ICommand _command;
        private IMapper _mapper;
        public WarehouseController(ICommand command, IMapper mapper)
        {
            _command = command;
            _mapper = mapper;
        }
        // GET api/Warehouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseReadDto>>>GetAllWareuses()
        {
            var commandItems = await _command.GetAllCommand();

            return Ok(_mapper.Map<IEnumerable<WarehouseReadDto>>(commandItems));
        }

        // GET api/Warehouse/5
        [HttpGet("{id}")]
        public ActionResult<WarehouseReadDto_Id> GetWarehouses(int? id)
        {
            if (id != null)
            {
                var commandById = _command.GetCommandById(id);

                return Ok(_mapper.Map<WarehouseReadDto_Id>(commandById));
            }
            return NotFound();
        }
        // PUT api/Warehouse/5
        [HttpPut("{id}")]
        public  ActionResult UpdateWarehouse(int id, WarehouseUpdateDto dto)
        {
            var commandId = _command.GetCommandById(id);
            if (commandId == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, commandId);
            _command.UpdateCommand(commandId);
            
            return Content("Данные успешно обновлены");
        }
        // Delete api/Warehouse/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandById(int? id)
        {
            if (id == null)
            {
                return BadRequest(ModelState);
            }
            _command.DeleteCommand(id);

            return Content("Данные успешно удалены");
        }
       
    }
}
