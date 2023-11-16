using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsManagement.DTOs.Requests;
using SportsManagement.Services.Abstract;

namespace SportsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] CreatePlayerRequestDTO playerRequest)
        {
            var response = _playerService.Add(playerRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return Created("/", response);
            return BadRequest(response);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var response = _playerService.GetById(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(response);
            return BadRequest(response);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var response = _playerService.Delete(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(response);
            return BadRequest(response);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _playerService.GetList();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
