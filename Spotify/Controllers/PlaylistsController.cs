using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Filters;
using Spotify.API.Interfaces;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : BaseController<PlaylistsController>
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistsController(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        [HttpPost("adicionar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Adicionar(PlaylistDTO dto)
        {
            await _playlistRepository.Adicionar(dto);
            return Ok(true);
        }

        [HttpPut("atualizar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Atualizar(PlaylistDTO dto)
        {
            await _playlistRepository.Atualizar(dto);
            return Ok(true);
        }

        [HttpDelete("deletar/{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<int>> Deletar(int id)
        {
            await _playlistRepository.Deletar(id);
            return Ok(true);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<PlaylistDTO>>> GetTodos()
        {
            var todos = await _playlistRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDTO>> GetById(int id)
        {
            var porId = await _playlistRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpGet("byUsuarioId/{id}")]
        public async Task<ActionResult<PlaylistDTO>> GetByUsuarioId(int id)
        {
            var porId = await _playlistRepository.GetByUsuarioId(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }
    }
}
