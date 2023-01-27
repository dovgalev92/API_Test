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
        public async Task <ActionResult<WarehouseReadDto_Id>> GetWarehouses(int? id)
        {
            if (ModelState.IsValid)
            {
                var commandById = await _command.GetCommandById(id);

                return Ok(_mapper.Map<WarehouseReadDto_Id>(commandById));
            }
            return NotFound();
        }
        //GET Warehouse/
        [HttpPost]
        public async Task<ActionResult> CreateCommand([FromBody] WarewhouseCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createDto = _mapper.Map<Warehouse>(dto);
            _command.CreateCommand(createDto);
            return Ok();
        }
       
       
    }
}
