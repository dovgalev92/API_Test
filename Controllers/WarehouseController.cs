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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>>GetAllWareuses()
        {
            var commandItems = await _command.GetAllCommand();

            return Ok(_mapper.Map<IEnumerable<WarehouseReadDto>>(commandItems));

        }
    }
}
