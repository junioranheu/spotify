using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Filters;
using Spotify.API.Interfaces;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : BaseController<LogsController>
    {
        private readonly ILogRepository _logRepository;

        public LogsController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpPost("adicionar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Adicionar(LogDTO dto)
        {
            await _logRepository.Adicionar(dto);
            return Ok(true);
        }

        [HttpGet("todos")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<List<LogDTO>>> GetTodos()
        {
            var todos = await _logRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<LogDTO>> GetById(int id)
        {
            var porId = await _logRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }
    }
}
